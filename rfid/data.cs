using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Newtonsoft.Json;
using rfid.entidades;
using System.Net.Http;
using rfid.utils;
using System.IO;
using System.Diagnostics;

namespace rfid
{
    public partial class data : Form
    {
        

        private BaseApiService<t001_items> t001_item_service;
        private BaseApiService<t0011_barras> t0011_barras_service;
        private BaseApiService<t004_ubicaciones> t004_ubicaciones_Service;
        private BaseApiService<t005_zonas> t005_zonas_service;
        private BaseApiService<t020_documentos> t020_documentos_service;

        public data()
        {
            InitializeComponent();
                      

            t001_item_service = new BaseApiService<t001_items>($"{config.ApiBaseUrl}item.php");
            t0011_barras_service = new BaseApiService<t0011_barras>($"{config.ApiBaseUrl}barras.php");
            t004_ubicaciones_Service = new BaseApiService<t004_ubicaciones>($"{config.ApiBaseUrl}ubicaciones.php");
            t005_zonas_service = new BaseApiService<t005_zonas>($"{config.ApiBaseUrl}zonas.php");
            t020_documentos_service = new BaseApiService<t020_documentos>($"{config.ApiBaseUrl}documentos.php");

            this.Location = new Point(170, 0);
            this.Size = new Size(630, 600);
        }

        private async void btnGuardar_t001_items_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog op = new OpenFileDialog();

                op.Filter = "Excel|*.xlsx";

                if (op.ShowDialog() != DialogResult.OK)
                    return;

                btnGuardar_t001_items.Enabled = false;

                await procesarExcel_t001_items(op.FileName);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                btnGuardar_t001_items.Enabled = true;
            }
        }
        public async Task procesarExcel_t001_items(string ruta) {

            List<t001_items> batch = new List<t001_items>();

            using (SpreadsheetDocument document =
            SpreadsheetDocument.Open(ruta, false))
            {
                WorkbookPart workbookPart =
                    document.WorkbookPart;

                SharedStringTablePart sharedStringPart =
                    workbookPart.SharedStringTablePart;

                WorksheetPart worksheetPart =
                    workbookPart.WorksheetParts.First();

                SheetData sheetData =
                    worksheetPart.Worksheet.Elements<SheetData>().First();

                bool primeraFila = true;

                foreach (Row row in sheetData.Elements<Row>())
                {
                    if (primeraFila)
                    {
                        primeraFila = false;
                        continue;
                    }

                    List<string> valores = new List<string>();

                    foreach (Cell cell in row.Elements<Cell>())
                    {
                        valores.Add(
                            ObtenerValorCelda(
                                cell,
                                sharedStringPart
                            )
                        );
                    }

                    if (valores.Count < 2)
                        continue;

                    t001_items item = new t001_items()
                    {
                        f001_codigo_item = valores[0]
                        ,f001_descripcion = valores[1]
                        ,f001_habilitado = 1
                        ,f001_creacion = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        

                       // precio = decimal.Parse(valores[2])
                    };

                    batch.Add(item);

                    if (batch.Count >= 500)
                    {
                        await EnviarBatch_t001_items(batch);

                        batch.Clear();
                    }
                }
            }

            if (batch.Count > 0)
            {
                await EnviarBatch_t001_items(batch);
            }

        }
        private async Task EnviarBatch_t001_items(List<t001_items> items)
        {
            var request = new
            {
                items = items
            };

            var response = await t001_item_service.CreateAsync(request);

            ApiResponse_lblInfo(response);

        }

        private string ObtenerValorCelda(Cell cell,SharedStringTablePart sharedStringPart)
        {
            if (cell.CellValue == null)
                return "";

            string value = cell.CellValue.InnerText;

            if (cell.DataType != null &&
                cell.DataType == CellValues.SharedString)
            {
                return sharedStringPart
                    .SharedStringTable
                    .ElementAt(int.Parse(value))
                    .InnerText;
            }

            return value;
        }
                      

        private List<string> ObtenerValoresFila(Row row, SharedStringTablePart sharedStringPart, int totalColumnas)
        {
            List<string> valores = Enumerable.Repeat("", totalColumnas).ToList();

            foreach (Cell cell in row.Elements<Cell>())
            {
                int indice = ObtenerIndiceColumna(cell.CellReference == null ? "" : cell.CellReference.Value);

                if (indice >= 0 && indice < totalColumnas)
                {
                    valores[indice] = ObtenerValorCelda(cell, sharedStringPart).Trim();
                }
            }

            return valores;
        }

        private int ObtenerIndiceColumna(string referenciaCelda)
        {
            int indice = 0;

            foreach (char caracter in referenciaCelda)
            {
                if (!char.IsLetter(caracter))
                    break;

                indice = (indice * 26) + (char.ToUpper(caracter) - 'A' + 1);
            }

            return indice - 1;
        }

        private async void btnGuardar_t0011_barras_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog op = new OpenFileDialog();

                op.Filter = "Excel|*.xlsx";

                if (op.ShowDialog() != DialogResult.OK)
                    return;

                btnGuardar_t0011.Enabled = false;

                await procesarExcel_t0011_barras(op.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                btnGuardar_t0011.Enabled = true;
            }
        }

        public async Task procesarExcel_t0011_barras(string ruta)
        {
            List<t0011_barras> batch = new List<t0011_barras>();
            List<t001_items> items = await t001_item_service.GetAllAsync();
            Dictionary<string, int> itemsPorCodigo = items
                .Where(item => !string.IsNullOrWhiteSpace(item.f001_codigo_item))
                .GroupBy(item => item.f001_codigo_item.Trim(), StringComparer.OrdinalIgnoreCase)
                .ToDictionary(grupo => grupo.Key, grupo => grupo.First().f001_id, StringComparer.OrdinalIgnoreCase);

            int filasOmitidas = 0;

            using (SpreadsheetDocument document = SpreadsheetDocument.Open(ruta, false))
            {
                WorkbookPart workbookPart = document.WorkbookPart;
                SharedStringTablePart sharedStringPart = workbookPart.SharedStringTablePart;
                WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();
                SheetData sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();

                bool primeraFila = true;

                foreach (Row row in sheetData.Elements<Row>())
                {
                    if (primeraFila)
                    {
                        primeraFila = false;
                        continue;
                    }

                    List<string> valores = ObtenerValoresFila(row, sharedStringPart, 8);

                    if (string.IsNullOrWhiteSpace(valores[0]) ||
                        string.IsNullOrWhiteSpace(valores[1]))
                    {
                        filasOmitidas++;
                        continue;
                    }

                    int idItem;
                    

                    if (!itemsPorCodigo.TryGetValue(valores[0], out idItem) )
                    {
                        filasOmitidas++;
                        continue;
                    }

                    t0011_barras barra = new t0011_barras()
                    {
                        f0011_id_item = idItem,
                        f0011_barra = valores[1],
                        f0011_atributo_1 = valores[2],
                        f0011_atributo_2 = valores[3],
                        f0011_atributo_3 = valores[4],
                        f0011_atributo_4 = valores[5],
                        f0011_atributo_5 = valores[6],
                        f0011_atributo_6 = valores[7],
                        f0011_habilitado = 1,
                        f0011_creacion = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                    };

                    batch.Add(barra);

                    if (batch.Count >= 500)
                    {
                        await EnviarBatch_t0011_barras(batch);
                        batch.Clear();
                    }
                }
            }

            if (batch.Count > 0)
            {
                await EnviarBatch_t0011_barras(batch);
            }

            if (filasOmitidas > 0)
            {
                MessageBox.Show($"Cargue terminado. Filas omitidas: {filasOmitidas}. Revise id/codigo de item y codigo de barras.");
            }
        }

        private bool ResolverIdItem(string valorItem, HashSet<int> itemsPorId, Dictionary<string, int> itemsPorCodigo, out int idItem)
        {
            idItem = 0;

            if (string.IsNullOrWhiteSpace(valorItem))
                return false;

            int idDesdeExcel;

            if (int.TryParse(valorItem.Trim(), out idDesdeExcel) && itemsPorId.Contains(idDesdeExcel))
            {
                idItem = idDesdeExcel;
                return true;
            }

            return itemsPorCodigo.TryGetValue(valorItem.Trim(), out idItem);
        }
        private async Task EnviarBatch_t0011_barras(List<t0011_barras> barras)
        {
            var request = new
            {
                barras = barras
            };

            var response = await t0011_barras_service.CreateAsync(request);

            ApiResponse_lblInfo(response);
        }
        private async void btnGuardar_t004_t005_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog op = new OpenFileDialog();

                op.Filter = "Excel|*.xlsx";

                if (op.ShowDialog() != DialogResult.OK)
                    return;

                btnGuardar_t004_t005.Enabled = false;

                await procesarExcel_t004_t005(op.FileName);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                btnGuardar_t004_t005.Enabled = true;
            }
        }

        public async Task procesarExcel_t004_t005(string ruta)
        {
            Dictionary<string, t004_ubicaciones> ubicacionesPorCodigo = new Dictionary<string, t004_ubicaciones>(StringComparer.OrdinalIgnoreCase);
            Dictionary<string, t005_zonas> zonasPorLlave = new Dictionary<string, t005_zonas>(StringComparer.OrdinalIgnoreCase);
            int filasOmitidas = 0;

            using (SpreadsheetDocument document = SpreadsheetDocument.Open(ruta, false))
            {
                WorkbookPart workbookPart = document.WorkbookPart;
                SharedStringTablePart sharedStringPart = workbookPart.SharedStringTablePart;
                WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();
                SheetData sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();

                bool primeraFila = true;

                foreach (Row row in sheetData.Elements<Row>())
                {
                    if (primeraFila)
                    {
                        primeraFila = false;
                        continue;
                    }

                    List<string> valores = ObtenerValoresFila(row, sharedStringPart, 6);

                    if (string.IsNullOrWhiteSpace(valores[0]) ||
                        string.IsNullOrWhiteSpace(valores[1]) ||
                        string.IsNullOrWhiteSpace(valores[4]) ||
                        string.IsNullOrWhiteSpace(valores[5]))
                    {
                        filasOmitidas++;
                        continue;
                    }

                    string codigoUbicacion = valores[0].Trim();
                    string codigoZona = valores[4].Trim();

                    if (!ubicacionesPorCodigo.ContainsKey(codigoUbicacion))
                    {
                        ubicacionesPorCodigo.Add(codigoUbicacion, new t004_ubicaciones()
                        {
                            f004_codigo_ubicacion = codigoUbicacion,
                            f004_descripcion = valores[1],
                            f004_ciudad = valores[2],
                            f004_direccion = valores[3],
                            f004_habilitado = 1,
                            f004_creacion = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        });
                    }

                    string llaveZona = CrearLlaveZona(codigoUbicacion, codigoZona);

                    if (!zonasPorLlave.ContainsKey(llaveZona))
                    {
                        zonasPorLlave.Add(llaveZona, new t005_zonas()
                        {
                            f005_id_ubicacion = codigoUbicacion,
                            f005_codigo_zona = codigoZona,
                            f005_descripcion = valores[5],
                            f005_habilitado = 1,
                            f005_creacion = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        });
                    }
                }
            }

            List<t004_ubicaciones> ubicaciones = ubicacionesPorCodigo.Values.ToList();
            List<t005_zonas> zonas = zonasPorLlave.Values.ToList();

            if (ubicaciones.Count > 0)
            {
                await EnviarBatch_t004(ubicaciones);
            }

            if (zonas.Count > 0)
            {
                await EnviarBatch_t005(zonas);
            }

            if (filasOmitidas > 0)
            {
                MessageBox.Show($"Cargue terminado. Filas omitidas: {filasOmitidas}. Revise ubicaciones y zonas obligatorias.");
            }
        }
        private async Task EnviarBatch_t004(List<t004_ubicaciones> ubicaciones)
        {
            var request_ubi = new
            {
                ubicaciones = ubicaciones
            };
           
            var response = await t004_ubicaciones_Service.CreateAsync(request_ubi);

            ApiResponse_lblInfo(response);

        }

        private async Task EnviarBatch_t005(List<t005_zonas> zonas)
        {
           
            var request_zona = new
            {
                zonas = zonas
            };

            var response = await t005_zonas_service.CreateAsync(request_zona);

            ApiResponse_lblInfo(response);

        }

        private void ApiResponse_lblInfo(ApiResponse response) {
            lbl_info.Text = "";
            lbl_log.Visible = false;
            lbl_info.Visible = false;

            if (response.StatusCode == 200)
            {
                lbl_info.Visible = true;
                lbl_info.Text = "Procesado.";

                string rutaArchivo = "log.txt";
                string mensajeLog = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] -[Success]: " + response.Success.ToString() + " [StatusCode]: " + response.StatusCode.ToString() + " [Content]: " + response.Content.ToString();

                File.AppendAllText(rutaArchivo, mensajeLog + Environment.NewLine);
            }
            else if (response.StatusCode == 500)
            {
                lbl_info.Visible = true;
                lbl_info.Text = "No procesado.";

                string rutaArchivo = "log.txt";
                string mensajeLog = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] -[Success]: " + response.Success.ToString() + " [StatusCode]: " + response.StatusCode.ToString() + " [Content]: " + response.Content.ToString();

                File.AppendAllText(rutaArchivo, mensajeLog + Environment.NewLine);

                lbl_log.Visible = true;

            }
            else {

                lbl_log.Visible = true;
                string rutaArchivo = "log.txt";
                string mensajeLog = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] -[Success]: " + response.Success.ToString() + " [StatusCode]: " + response.StatusCode.ToString() + " [Content]: " + response.Content.ToString();

                File.AppendAllText(rutaArchivo, mensajeLog + Environment.NewLine);

            }
            
        }

        private void lbl_log_Click(object sender, EventArgs e)
        {
            Process.Start("log.txt");
        }

        private async void btnGuardar_t020_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog op = new OpenFileDialog();

                op.Filter = "Excel|*.xlsx";

                if (op.ShowDialog() != DialogResult.OK)
                    return;

                btnGuardar_t020.Enabled = false;

                await procesarExcel_t020_documentos(op.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                btnGuardar_t020.Enabled = true;
            }
        }

        public async Task procesarExcel_t020_documentos(string ruta)
        {
            List<t0011_barras> barras = await t0011_barras_service.GetAllAsync();
            List<t004_ubicaciones> ubicaciones = await t004_ubicaciones_Service.GetAllAsync();
            List<t005_zonas> zonas = await t005_zonas_service.GetAllAsync();

            Dictionary<string, int> barrasPorCodigo = barras
                .Where(barra => !string.IsNullOrWhiteSpace(barra.f0011_barra))
                .GroupBy(barra => barra.f0011_barra.Trim(), StringComparer.OrdinalIgnoreCase)
                .ToDictionary(grupo => grupo.Key, grupo => grupo.First().f0011_id, StringComparer.OrdinalIgnoreCase);

            Dictionary<string, int> ubicacionesPorCodigo = ubicaciones
                .Where(ubicacion => !string.IsNullOrWhiteSpace(ubicacion.f004_codigo_ubicacion))
                .GroupBy(ubicacion => ubicacion.f004_codigo_ubicacion.Trim(), StringComparer.OrdinalIgnoreCase)
                .ToDictionary(grupo => grupo.Key, grupo => grupo.First().f004_id, StringComparer.OrdinalIgnoreCase);

            Dictionary<string, int> zonasPorCodigo = zonas
                .Where(zona => !string.IsNullOrWhiteSpace(zona.f005_id_ubicacion) && !string.IsNullOrWhiteSpace(zona.f005_codigo_zona))
                .GroupBy(zona => CrearLlaveZona(zona.f005_id_ubicacion, zona.f005_codigo_zona), StringComparer.OrdinalIgnoreCase)
                .ToDictionary(grupo => grupo.Key, grupo => grupo.First().f005_id, StringComparer.OrdinalIgnoreCase);

            Dictionary<string, DocumentoEntradaCarga> documentosPorLlave = new Dictionary<string, DocumentoEntradaCarga>(StringComparer.OrdinalIgnoreCase);
            int filasOmitidas = 0;

            using (SpreadsheetDocument document = SpreadsheetDocument.Open(ruta, false))
            {
                WorkbookPart workbookPart = document.WorkbookPart;
                SharedStringTablePart sharedStringPart = workbookPart.SharedStringTablePart;
                WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();
                SheetData sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();

                bool primeraFila = true;

                foreach (Row row in sheetData.Elements<Row>())
                {
                    if (primeraFila)
                    {
                        primeraFila = false;
                        continue;
                    }

                    List<string> valores = ObtenerValoresFila(row, sharedStringPart, 8);

                    string tipoDocumento = valores[0];
                    string numeroDocumento = valores[1];
                    string fechaDocumento = NormalizarFechaDocumento(valores[2]);
                    string origen = valores[3];
                    string codigoBarra = valores[4];
                    string codigoUbicacion = valores[5];
                    string codigoZona = valores[6];
                    string valorCantidad = valores[7];

                    if (string.IsNullOrWhiteSpace(tipoDocumento) ||
                        string.IsNullOrWhiteSpace(numeroDocumento) ||
                        string.IsNullOrWhiteSpace(codigoBarra) ||
                        string.IsNullOrWhiteSpace(codigoUbicacion) ||
                        string.IsNullOrWhiteSpace(codigoZona) ||
                        string.IsNullOrWhiteSpace(valorCantidad))
                    {
                        filasOmitidas++;
                        continue;
                    }

                    int idBarra;
                    int idUbicacion;
                    int idZona;
                    int cantidad;

                    if (!barrasPorCodigo.TryGetValue(codigoBarra.Trim(), out idBarra) 
                        || !ubicacionesPorCodigo.TryGetValue(codigoUbicacion.Trim(), out idUbicacion) 
                        || !zonasPorCodigo.TryGetValue(CrearLlaveZona(idUbicacion.ToString(), codigoZona), out idZona) 
                        || !TryParseCantidad(valorCantidad, out cantidad)
                        )
                    {
                        filasOmitidas++;
                        continue;
                    }

                    string llaveDocumento = CrearLlaveDocumento(tipoDocumento, numeroDocumento, fechaDocumento, origen);
                    DocumentoEntradaCarga documentoCarga;

                    if (!documentosPorLlave.TryGetValue(llaveDocumento, out documentoCarga))
                    {
                        documentoCarga = new DocumentoEntradaCarga
                        {
                            documento = new t020_documentos
                            {
                                f020_tipo_documento = tipoDocumento.Trim(),
                                f020_numero_documento = numeroDocumento.Trim(),
                                f020_fecha_documento = fechaDocumento,
                                f020_origen = origen.Trim(),
                                f020_estado = "PENDIENTE",
                                f020_habilitado = 1,
                                f020_creacion = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                            },
                            detalles = new List<t021_documentos_detalle>()
                        };

                        documentosPorLlave.Add(llaveDocumento, documentoCarga);
                    }

                    documentoCarga.detalles.Add(new t021_documentos_detalle
                    {
                        f021_id_documento = 0,
                        f021_id_barra = idBarra,
                        f021_id_ubicacion = idUbicacion,
                        f021_id_zona = idZona,
                        f021_cantidad = cantidad,
                        f021_cantidad_epc_generada = 0,
                        f021_cantidad_impresa = 0,
                        f021_estado = "PENDIENTE",
                        f021_habilitado = 1,
                        f021_creacion = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                    });
                }
            }

            if (documentosPorLlave.Count > 0)
            {
                await EnviarBatch_t020_documentos(documentosPorLlave.Values.ToList());
            }

            if (filasOmitidas > 0)
            {
                MessageBox.Show($"Cargue terminado. Filas omitidas: {filasOmitidas}. Revise documento, barra, ubicacion, zona y cantidad.");
            }
        }

        private async Task EnviarBatch_t020_documentos(List<DocumentoEntradaCarga> documentos)
        {
            var request = new
            {
                documentos = documentos
            };

            var response = await t020_documentos_service.CreateAsync(request);

            ApiResponse_lblInfo(response);
        }

        private string CrearLlaveDocumento(string tipoDocumento, string numeroDocumento, string fechaDocumento, string origen)
        {
            return $"{tipoDocumento.Trim()}|{numeroDocumento.Trim()}|{fechaDocumento.Trim()}|{origen.Trim()}";
        }

        private string CrearLlaveZona(string codigoUbicacion, string codigoZona)
        {
            return $"{codigoUbicacion.Trim()}|{codigoZona.Trim()}";
        }

        private string NormalizarFechaDocumento(string valorFecha)
        {
            if (string.IsNullOrWhiteSpace(valorFecha))
                return "";

            double fechaOa;
            DateTime fecha;

            if (double.TryParse(valorFecha, out fechaOa) && fechaOa > 0)
            {
                return DateTime.FromOADate(fechaOa).ToString("yyyy-MM-dd");
            }

            if (DateTime.TryParse(valorFecha, out fecha))
            {
                return fecha.ToString("yyyy-MM-dd");
            }

            return valorFecha.Trim();
        }

        private bool TryParseCantidad(string valorCantidad, out int cantidad)
        {
            cantidad = 0;
            decimal cantidadDecimal;

            if (!decimal.TryParse(valorCantidad, out cantidadDecimal))
                return false;

            if (cantidadDecimal <= 0 || cantidadDecimal != Math.Truncate(cantidadDecimal))
                return false;

            cantidad = Convert.ToInt32(cantidadDecimal);
            return true;
        }

        private class DocumentoEntradaCarga
        {
            public t020_documentos documento { get; set; }
            public List<t021_documentos_detalle> detalles { get; set; }
        }
    }
}

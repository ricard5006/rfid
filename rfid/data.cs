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
        private BaseApiService<t004_ubicaciones> t004_ubicaciones_Service;
        private BaseApiService<t005_zonas> t005_zonas_service;

        public data()
        {
            InitializeComponent();
                      

            t001_item_service = new BaseApiService<t001_items>($"{config.ApiBaseUrl}item.php");
            t004_ubicaciones_Service = new BaseApiService<t004_ubicaciones>($"{config.ApiBaseUrl}ubicaciones.php");
            t005_zonas_service = new BaseApiService<t005_zonas>($"{config.ApiBaseUrl}zonas.php");

            this.Location = new Point(170, 0);
            this.Size = new Size(630, 600);
        }

        private void btnGuardar_t001_items_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog op = new OpenFileDialog();

                op.Filter = "Excel|*.xlsx";

                if (op.ShowDialog() != DialogResult.OK)
                    return;

                btnGuardar_t001_items.Enabled = false;

                procesarExcel_t001_items(op.FileName);


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

                    if (valores.Count < 3)
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

        

        

        private void btnGuardar_t004_t005_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog op = new OpenFileDialog();

                op.Filter = "Excel|*.xlsx";

                if (op.ShowDialog() != DialogResult.OK)
                    return;

                btnGuardar_t004_t005.Enabled = false;

                procesarExcel_t004_t005(op.FileName);


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

            List<t004_ubicaciones> batch_ubi = new List<t004_ubicaciones>();
            List<t005_zonas> batch_zna = new List<t005_zonas>();

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

                    if (valores.Count < 3)
                        continue;

                    t004_ubicaciones ubicaciones = new t004_ubicaciones()
                    {
                        f004_codigo_ubicacion = valores[0]
                        ,f004_descripcion = valores[1]
                        ,f004_ciudad = valores[2]
                        ,f004_direccion = valores[3]
                        ,f004_habilitado = 1
                        ,f004_creacion = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

                    };

                    t005_zonas zonas = new t005_zonas()
                    {
                        f005_id_ubicacion = valores[0]

                        ,f005_codigo_zona = valores[4]
                        ,f005_descripcion = valores[5]
                        ,f005_habilitado = 1
                        ,f005_creacion = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

                    };
                    
                    batch_ubi.Add(ubicaciones);

                    batch_zna.Add(zonas);

                    if (batch_ubi.Count >= 500)
                    {
                        await EnviarBatch_t004(batch_ubi);
                        await EnviarBatch_t005(batch_zna);

                        batch_ubi.Clear();
                        batch_zna.Clear();
                    }
                }
            }

            if (batch_ubi.Count > 0)
            {
                await EnviarBatch_t004(batch_ubi);
                await EnviarBatch_t005(batch_zna);
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

            var response = await t004_ubicaciones_Service.CreateAsync(request_zona);

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

        
    }
}

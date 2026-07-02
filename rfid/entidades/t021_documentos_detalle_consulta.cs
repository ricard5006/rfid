using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rfid.entidades
{
    public class t021_documentos_detalle_consulta
    {
        public int f021_id { get; set; }
        public int f021_id_documento { get; set; }
        public string f001_codigo_item { get; set; }
        public string f001_descripcion { get; set; }
        public string f0011_barra { get; set; }
        public string f0011_atributo_1 { get; set; }
        public string f0011_atributo_2 { get; set; }
        public string f0011_atributo_3 { get; set; }
        public string f0011_atributo_4 { get; set; }
        public string f0011_atributo_5 { get; set; }
        public string f0011_atributo_6 { get; set; }
        public string f004_codigo_ubicacion { get; set; }
        public string f004_descripcion { get; set; }
        public string f005_codigo_zona { get; set; }
        public string f005_descripcion { get; set; }
        public int f021_cantidad { get; set; }
        public int f021_cantidad_epc_generada { get; set; }
        public int f021_cantidad_impresa { get; set; }
        public int cantidad_pendiente_epc { get; set; }
        public int cantidad_pendiente_impresion { get; set; }
        public string f021_estado { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rfid.entidades
{
    public class t021_documentos_detalle
    {
        public int f021_id { get; set; }
        public int f021_id_documento { get; set; }
        public int f021_id_barra { get; set; }
        public int f021_id_ubicacion { get; set; }
        public int f021_id_zona { get; set; }
        public int f021_cantidad { get; set; }
        public int f021_cantidad_epc_generada { get; set; }
        public int f021_cantidad_impresa { get; set; }
        public string f021_estado { get; set; }
        public int f021_habilitado { get; set; }
        public string f021_creacion { get; set; }
        public string f021_actualizacion { get; set; }
    }
}
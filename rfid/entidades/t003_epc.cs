using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rfid.entidades
{
    public class t003_epc
    {
        public int f003_id { get; set; }
        public int f003_id_barra { get; set; }
        public int f003_id_documento_detalle { get; set; }
        public string f003_epc { get; set; }
        public int f003_impreso { get; set; }
        public int f003_habilitado { get; set; }
        public string f003_creacion { get; set; }
        public string f003_actualizacion { get; set; }
    }
}
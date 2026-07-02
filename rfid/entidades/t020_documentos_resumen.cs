using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rfid.entidades
{
    public class t020_documentos_resumen
    {
        public int f020_id { get; set; }
        public string f020_tipo_documento { get; set; }
        public string f020_numero_documento { get; set; }
        public string f020_fecha_documento { get; set; }
        public string f020_origen { get; set; }
        public string f020_estado { get; set; }
        public int f020_habilitado { get; set; }
        public int cantidad_total { get; set; }
        public int cantidad_epc_generada { get; set; }
        public int cantidad_impresa { get; set; }
        public int cantidad_pendiente_epc { get; set; }
        public int cantidad_pendiente_impresion { get; set; }
    }
}
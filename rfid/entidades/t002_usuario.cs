using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace rfid.entidades
{
    public class t002_usuarios
    {
        public int f002_id { get; set; }

        [JsonProperty("f002_usuario")] //lo dejo aqui para recordar, se peude usar en otro momento
        public string f002_usuario { get; set; }       
        public string f002_contrasena { get; set; }        
        public int f002_habilitado { get; set; }
        public string f002_creacion { get; set; }
        public string f002_actualizacion { get; set; }


    }
}

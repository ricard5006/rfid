using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.IO;

namespace rfid
{
    public static class config
    {
        private static readonly JObject Config =
        JObject.Parse(File.ReadAllText("appsettings.json"));

        public static string ApiBaseUrl => Config["ApiBaseUrl"].ToString();

    }
}

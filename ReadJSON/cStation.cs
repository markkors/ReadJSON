using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadJSON
{
    [JsonObject(ItemRequired = Required.Default)]
    public class cStation
    {

        

        public string stationid { get; set; }
        public string stationname { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
        public string regio { get; set; }
        public string timestamp { get; set; }
        public string weatherdescription { get; set; } = null;
        public string iconurl { get; set; }
        public string graphurl { get; set; }
        public string winddirection { get; set; } = null;
        public double windgusts { get; set; } = -100000;
        public double windspeed { get; set; } = -100000;
        public int windBft { get; set; } = -100000;
        public double winddirectiondegrees { get; set; } = -100000;
        public double temperature { get; set; } = -100000;
        public double feeltemperature { get; set; } = -100000;
        public double groundtemperature { get; set; } = -100000;
        public double humidity { get; set; } = -100000;
        public double precipitation { get; set; } = -100000;
        public double sunpower { get; set; } = -100000;
        public double rainFallLast24Hour { get; set; } = -100000;
        public double rainFallLastHour { get; set; } = -100000;
    }
       
       
}

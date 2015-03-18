using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestCallsTests.controller
{
    public class Meter
    {
        [DeserializeAs(Name = "id")]
        public string id { get; set; }
        [DeserializeAs(Name = "meterIdentification")]
        public string meterIdentification { get; set; }
        [DeserializeAs(Name = "name")]
        public string name { get; set; }
        [DeserializeAs(Name = "supplier")]
        public string supplier { get; set; }
        [DeserializeAs(Name = "type")]
        public string type { get; set; }
        [DeserializeAs(Name = "unit")]
        public string unit { get; set; }
    }
}

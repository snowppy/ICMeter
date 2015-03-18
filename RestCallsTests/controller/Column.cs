using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestCallsTests.controller
{
    [DeserializeAs(Name = "Col")]
    public class Column
    {
        public string id { get; set; }
        public string label { get; set; }
        public string type { get; set; }
        public string pattern { get; set; }
    }
}

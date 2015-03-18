using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestCallsTests.controller
{
    public class GrossArea
    {
        [DeserializeAs(Name = "value")]
        public string value { get; set; }
        [DeserializeAs(Name = "unit")]
        public string unit { get; set; }
    }
}

using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestCallsTests.controller
{
    [DeserializeAs(Name = "C")]
    public class Cell
    {
        [DeserializeAs(Name = "v")]
        public string value { get; set; }
    }
}

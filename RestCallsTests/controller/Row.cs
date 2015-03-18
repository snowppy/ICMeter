using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestCallsTests.controller
{
    [DeserializeAs(Name = "Row")]
    public class Row
    {
        [DeserializeAs(Name = "c")]
        public List<Cell> cells{ get; set; }
    }
}

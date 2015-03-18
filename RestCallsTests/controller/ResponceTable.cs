using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestCallsTests.controller
{
     public class ResponceTable
    {
        [DeserializeAs(Name = "cols")]
        public List<Column> columns { get; set; }
        [DeserializeAs(Name = "rows")]
        public List<Row> rows { get; set; }
    }
}

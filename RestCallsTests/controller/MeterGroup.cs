using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestCallsTests.controller
{
    public class MeterGroup
    {
        [DeserializeAs(Name = "groupId")]
        public object groupId { get; set; }
        [DeserializeAs(Name = "group")]
        public string group { get; set; }
        [DeserializeAs(Name = "type")]
        public string type { get; set; }

        [DeserializeAs(Name = "grossArea")]
        public GrossArea grossArea { get; set; }

        [DeserializeAs(Name = "meters")]
        public List<Meter> meters { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebApplicationExample.Entities
{
    public class Contract
    {
        [JsonIgnore]
        public Guid CorrelationId { get; set; }

        public int TypeId { get; set; }

        public int OrganizationId { get; set; }

        public string NameContract { get; set; }

        //[JsonIgnore]
        public TypeTemplate TypeTemplate { get; set; }
    }
}

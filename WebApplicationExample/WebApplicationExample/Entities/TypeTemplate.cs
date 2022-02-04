using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationExample.Entities
{
    public class TypeTemplate
    {
        public int TypeId { get; set; }

        public int OrganizationId { get; set; }

        public string Name { get; set; }

        public Organization Organization { get; set; }

        public ICollection<Contract> Contracts { get; set; }
    }
}

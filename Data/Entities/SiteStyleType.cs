using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class SiteStyleType
    {
        public SiteStyleType()
        {
            Employee = new HashSet<Employee>();
        }

        public int UniqueId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}

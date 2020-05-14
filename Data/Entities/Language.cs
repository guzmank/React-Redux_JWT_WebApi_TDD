using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class Language
    {
        public Language()
        {
            Employee = new HashSet<Employee>();
            VersionHistory = new HashSet<VersionHistory>();
        }

        public Guid UniqueId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
        public virtual ICollection<VersionHistory> VersionHistory { get; set; }
    }
}

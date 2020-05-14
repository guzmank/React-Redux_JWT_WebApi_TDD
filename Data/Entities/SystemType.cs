using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class SystemType
    {
        public SystemType()
        {
            VersionHistory = new HashSet<VersionHistory>();
        }

        public Guid UniqueId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<VersionHistory> VersionHistory { get; set; }
    }
}

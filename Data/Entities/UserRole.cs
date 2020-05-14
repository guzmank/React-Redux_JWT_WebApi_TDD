using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class UserRole
    {
        public Guid UniqueId { get; set; }
        public Guid UserUniqueId { get; set; }
        public Guid RoleUniqueId { get; set; }

        public virtual Role RoleUnique { get; set; }
        public virtual User UserUnique { get; set; }
    }
}

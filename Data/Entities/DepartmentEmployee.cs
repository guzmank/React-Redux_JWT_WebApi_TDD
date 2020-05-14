using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class DepartmentEmployee
    {
        public Guid UniqueId { get; set; }
        public Guid DepartmentUniqueId { get; set; }
        public Guid EmployeeUniqueId { get; set; }

        public virtual Department DepartmentUnique { get; set; }
        public virtual Employee EmployeeUnique { get; set; }
    }
}

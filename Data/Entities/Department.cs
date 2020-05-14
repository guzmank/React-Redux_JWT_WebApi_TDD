using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class Department
    {
        public Department()
        {
            DepartmentEmployee = new HashSet<DepartmentEmployee>();
        }

        public Guid UniqueId { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public Guid CompanyUniqueId { get; set; }
        public bool Deleted { get; set; }

        public virtual Company CompanyUnique { get; set; }
        public virtual ICollection<DepartmentEmployee> DepartmentEmployee { get; set; }
    }
}

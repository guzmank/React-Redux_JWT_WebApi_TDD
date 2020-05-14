using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class Employee
    {
        public Employee()
        {
            DepartmentEmployee = new HashSet<DepartmentEmployee>();
        }

        public Guid UniqueId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Initials { get; set; }
        public string EmployeeNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public string IdCard { get; set; }
        public string Phone { get; set; }
        public string Mobil { get; set; }
        public int GenderUniqueId { get; set; }
        public Guid UserUniqueId { get; set; }
        public Guid LanguageUniqueId { get; set; }
        public int SiteStyleTypeUniqueId { get; set; }

        public virtual Gender GenderUnique { get; set; }
        public virtual Language LanguageUnique { get; set; }
        public virtual SiteStyleType SiteStyleTypeUnique { get; set; }
        public virtual User UserUnique { get; set; }
        public virtual ICollection<DepartmentEmployee> DepartmentEmployee { get; set; }
    }
}

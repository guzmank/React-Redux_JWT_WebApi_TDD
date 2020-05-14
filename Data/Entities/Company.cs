using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class Company
    {
        public Company()
        {
            Department = new HashSet<Department>();
        }

        public Guid UniqueId { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string CountryCode { get; set; }
        public string OrganizationNumber { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Department> Department { get; set; }
    }
}

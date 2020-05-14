using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class User
    {
        public User()
        {
            Employee = new HashSet<Employee>();
            UserRole = new HashSet<UserRole>();
        }

        public Guid UniqueId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}

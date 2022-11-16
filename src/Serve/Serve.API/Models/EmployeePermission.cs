using System;
using System.Collections.Generic;

namespace Serve.API.Models
{
    public partial class EmployeePermission
    {
        public EmployeePermission()
        {
            OrganizationEmployees = new HashSet<OrganizationEmployee>();
        }

        public int Id { get; set; }
        public int? RoleId { get; set; }
        public string Name { get; set; } = null!;
        public long OrganizationId { get; set; }

        public virtual Organization Organization { get; set; } = null!;
        public virtual EmployeeRole? Role { get; set; }
        public virtual ICollection<OrganizationEmployee> OrganizationEmployees { get; set; }
    }
}

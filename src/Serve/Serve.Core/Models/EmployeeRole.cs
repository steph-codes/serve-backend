using System;
using System.Collections.Generic;

namespace Serve.Core.Models
{
    public partial class EmployeeRole
    {
        public EmployeeRole()
        {
            EmployeePermissions = new HashSet<EmployeePermission>();
            OrganizationEmployees = new HashSet<OrganizationEmployee>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int OrganizationEmployeeId { get; set; }
        public long OrganizationId { get; set; }

        public virtual Organization Organization { get; set; } = null!;
        public virtual OrganizationEmployee OrganizationEmployee { get; set; } = null!;
        public virtual ICollection<EmployeePermission> EmployeePermissions { get; set; }
        public virtual ICollection<OrganizationEmployee> OrganizationEmployees { get; set; }
    }
}

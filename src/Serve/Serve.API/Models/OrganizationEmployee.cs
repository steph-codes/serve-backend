using System;
using System.Collections.Generic;

namespace Serve.API.Models
{
    public partial class OrganizationEmployee
    {
        public OrganizationEmployee()
        {
            AppointmentHandlers = new HashSet<AppointmentHandler>();
            EmployeeRoles = new HashSet<EmployeeRole>();
            EmployeeUnavailableDates = new HashSet<EmployeeUnavailableDate>();
            Notifications = new HashSet<Notification>();
        }

        public int Id { get; set; }
        public long? OrganizationId { get; set; }
        public long ProfileId { get; set; }
        public int RoleId { get; set; }
        public int PermissionId { get; set; }

        public virtual Organization? Organization { get; set; }
        public virtual EmployeePermission Permission { get; set; } = null!;
        public virtual UserProfile Profile { get; set; } = null!;
        public virtual EmployeeRole Role { get; set; } = null!;
        public virtual ICollection<AppointmentHandler> AppointmentHandlers { get; set; }
        public virtual ICollection<EmployeeRole> EmployeeRoles { get; set; }
        public virtual ICollection<EmployeeUnavailableDate> EmployeeUnavailableDates { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
    }
}

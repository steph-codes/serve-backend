using System;
using System.Collections.Generic;

namespace Serve.Core.Models
{
    public partial class AppointmentHandler
    {
        public long Id { get; set; }
        public int? EmployeeId { get; set; }
        public int? AppointmentId { get; set; }

        public virtual Appointment? Appointment { get; set; }
        public virtual OrganizationEmployee? Employee { get; set; }
    }
}

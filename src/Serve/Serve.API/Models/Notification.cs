using System;
using System.Collections.Generic;

namespace Serve.API.Models
{
    public partial class Notification
    {
        public long Id { get; set; }
        public int? AppointmentId { get; set; }
        public string? EventId { get; set; }
        public long? OrganizationId { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? Time { get; set; }
        public byte? Status { get; set; }
        public int? ReminderId { get; set; }

        public virtual Appointment? Appointment { get; set; }
        public virtual OrganizationEmployee? Employee { get; set; }
        public virtual Organization? Organization { get; set; }
        public virtual Reminder? Reminder { get; set; }
    }
}

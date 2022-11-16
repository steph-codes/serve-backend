using System;
using System.Collections.Generic;

namespace Serve.API.Models
{
    public partial class Event
    {
        public Event()
        {
            Reminders = new HashSet<Reminder>();
        }

        public int Id { get; set; }
        public int? AppointmentId { get; set; }
        public long? OrganizationId { get; set; }
        public int? EventTypeId { get; set; }
        public int? ReminderId { get; set; }
        public string? EventUrl { get; set; }
        public DateTime? ScheduledAt { get; set; }
        public DateTime? TriggeredAt { get; set; }
        public int? EmployeeId { get; set; }

        public virtual EventType? EventType { get; set; }
        public virtual Reminder? Reminder { get; set; }
        public virtual ICollection<Reminder> Reminders { get; set; }
    }
}

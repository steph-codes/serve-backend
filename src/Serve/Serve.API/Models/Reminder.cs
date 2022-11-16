using System;
using System.Collections.Generic;

namespace Serve.API.Models
{
    public partial class Reminder
    {
        public Reminder()
        {
            Events = new HashSet<Event>();
            Notifications = new HashSet<Notification>();
        }

        public int Id { get; set; }
        public int? EventId { get; set; }
        public int? ReminderCount { get; set; }
        public long? OrganizationId { get; set; }
        public int? ReminderStatusId { get; set; }
        public string? Message { get; set; }
        public int? ReminderType { get; set; }
        public byte? ReminderUnit { get; set; }
        public int? ReminderInterval { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Event? Event { get; set; }
        public virtual ReminderStatus? ReminderStatus { get; set; }
        public virtual ReminderType? ReminderTypeNavigation { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
    }
}

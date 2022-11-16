using System;
using System.Collections.Generic;

namespace Serve.Core.Models
{
    public partial class ReminderStatus
    {
        public ReminderStatus()
        {
            Reminders = new HashSet<Reminder>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Reminder> Reminders { get; set; }
    }
}

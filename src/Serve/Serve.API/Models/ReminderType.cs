﻿using System;
using System.Collections.Generic;

namespace Serve.API.Models
{
    public partial class ReminderType
    {
        public ReminderType()
        {
            Reminders = new HashSet<Reminder>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Reminder> Reminders { get; set; }
    }
}

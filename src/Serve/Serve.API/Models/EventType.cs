using System;
using System.Collections.Generic;

namespace Serve.API.Models
{
    public partial class EventType
    {
        public EventType()
        {
            Events = new HashSet<Event>();
        }

        public int Id { get; set; }
        public string? EventName { get; set; }
        public string? EventDescription { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}

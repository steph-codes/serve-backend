using System;
using System.Collections.Generic;

namespace Serve.Core.Models
{
    public partial class AppointmentService
    {
        public int Id { get; set; }
        public int? ServiceId { get; set; }
        public int? AppointmentId { get; set; }
        public decimal? Cost { get; set; }

        public virtual Appointment? Appointment { get; set; }
        public virtual Service? Service { get; set; }
    }
}

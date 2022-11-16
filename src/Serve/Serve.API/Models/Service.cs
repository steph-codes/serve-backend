using System;
using System.Collections.Generic;

namespace Serve.API.Models
{
    public partial class Service
    {
        public Service()
        {
            AppointmentServices = new HashSet<AppointmentService>();
        }

        public int Id { get; set; }
        public int Unit { get; set; }
        public decimal? Price { get; set; }
        public int? Value { get; set; }
        public string? ServiceName { get; set; }
        public decimal? BaseFee { get; set; }
        public string? Currency { get; set; }

        public virtual ICollection<AppointmentService> AppointmentServices { get; set; }
    }
}

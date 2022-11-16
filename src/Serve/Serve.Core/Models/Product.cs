using System;
using System.Collections.Generic;

namespace Serve.Core.Models
{
    public partial class Product
    {
        public Product()
        {
            AppointmentProducts = new HashSet<AppointmentProduct>();
        }

        public long Id { get; set; }
        public decimal? Amount { get; set; }
        public int? AppointmentId { get; set; }
        public string? ProductName { get; set; }
        public decimal? Price { get; set; }

        public virtual Appointment? Appointment { get; set; }
        public virtual ICollection<AppointmentProduct> AppointmentProducts { get; set; }
    }
}

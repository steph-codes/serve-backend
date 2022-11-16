using System;
using System.Collections.Generic;

namespace Serve.Core.Models
{
    public partial class Appointment
    {
        public Appointment()
        {
            AppointmentHandlers = new HashSet<AppointmentHandler>();
            AppointmentServices = new HashSet<AppointmentService>();
            Notifications = new HashSet<Notification>();
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string? AppointmentTitle { get; set; }
        public long? OrganizationId { get; set; }
        public int? CustomerId { get; set; }
        public decimal? Price { get; set; }
        public bool? Canceled { get; set; }
        public string? CancelReason { get; set; }
        public DateTime? EndDateTime { get; set; }
        public DateTime? StartDateTime { get; set; }
        public string? Address { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? Longitude { get; set; }
        public string? Latitude { get; set; }
        public string? Url { get; set; }

        public string? AppointmentStatus { get; set; }
        public string? Location { get; set; }


        public virtual Customer? Customer { get; set; }
        public virtual ICollection<AppointmentHandler> AppointmentHandlers { get; set; }
        public virtual ICollection<AppointmentService> AppointmentServices { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}

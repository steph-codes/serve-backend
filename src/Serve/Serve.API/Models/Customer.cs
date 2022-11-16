using System;
using System.Collections.Generic;

namespace Serve.API.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Appointments = new HashSet<Appointment>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string CustomerName { get; set; } = null!;
        public string CustomerEmail { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public short? Gender { get; set; }
        public string? AuthType { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}

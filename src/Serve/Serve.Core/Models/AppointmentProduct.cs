using System;
using System.Collections.Generic;

namespace Serve.Core.Models
{
    public partial class AppointmentProduct
    {
        public long Id { get; set; }
        public long? ProductId { get; set; }

        public virtual Product? Product { get; set; }
    }
}

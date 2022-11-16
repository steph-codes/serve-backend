using System;
using System.Collections.Generic;

namespace Serve.API.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public long OrganizationId { get; set; }
        public int CustomerId { get; set; }
        public string? AuthType { get; set; }
        public string? Password { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual Organization Organization { get; set; } = null!;
    }
}

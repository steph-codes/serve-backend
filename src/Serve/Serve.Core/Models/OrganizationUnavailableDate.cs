using System;
using System.Collections.Generic;

namespace Serve.Core.Models
{
    public partial class OrganizationUnavailableDate
    {
        public int Id { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EnddateTime { get; set; }
        public long? OrganizationId { get; set; }
        public string? Description { get; set; }

        public virtual Organization? Organization { get; set; }
    }
}

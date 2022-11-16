using System;
using System.Collections.Generic;

namespace Serve.Core.Models
{
    public partial class OrganizationMedium
    {
        public long Id { get; set; }
        public string? MediaName { get; set; }
        public string? MediaType { get; set; }
        public string? MediaDescription { get; set; }
        public string? MediaCaption { get; set; }
        public long? OrganizationId { get; set; }

        public virtual Organization? Organization { get; set; }
    }
}

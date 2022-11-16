using System;
using System.Collections.Generic;

namespace Serve.API.Models
{
    public partial class CollaborativeTool
    {
        public int Id { get; set; }
        public long? OrganizationId { get; set; }
        public int? CustomerId { get; set; }
        public string? ToolName { get; set; }
        public string? ToolUrl { get; set; }
    }
}

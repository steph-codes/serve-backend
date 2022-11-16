using System;
using System.Collections.Generic;

namespace Serve.Core.Models
{
    public partial class EmployeeUnavailableDate
    {
        public int Id { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public int? EmployeeId { get; set; }

        public virtual OrganizationEmployee? Employee { get; set; }
    }
}

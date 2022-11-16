using System;
using System.Collections.Generic;

namespace Serve.API.Models
{
    public partial class Task
    {
        public Task()
        {
            Timesheets = new HashSet<Timesheet>();
        }

        public int Id { get; set; }
        public string? TaskTittle { get; set; }
        public DateTime? Duration { get; set; }
        public string? TaskDescription { get; set; }
        public int? EmployeeId { get; set; }
        public int? UserProfileId { get; set; }
        public long? OrganizationId { get; set; }

        public virtual ICollection<Timesheet> Timesheets { get; set; }
    }
}

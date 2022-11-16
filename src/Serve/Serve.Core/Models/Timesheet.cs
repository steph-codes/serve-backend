using System;
using System.Collections.Generic;

namespace Serve.Core.Models
{
    public partial class Timesheet
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string? AttendanceByDay { get; set; }
        public DateTime? ShiftStart { get; set; }
        public string? ShiftEnd { get; set; }
        public bool ApprovedTimesheet { get; set; }
        public int? ApprovedBy { get; set; }
        public DateTime? ApprovedAt { get; set; }
        public int? TaskId { get; set; }

        public virtual Task? Task { get; set; }
    }
}

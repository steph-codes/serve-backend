using System;
using System.Collections.Generic;

namespace Serve.Core.Models
{
    public partial class Schedule
    {
        public int SchId { get; set; }
        public DateTime? StartFrom { get; set; }
        public DateTime? FinishAt { get; set; }
    }
}

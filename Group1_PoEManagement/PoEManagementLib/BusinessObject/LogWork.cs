using System;
using System.Collections.Generic;

#nullable disable

namespace PoEManagementLib.BusinessObject
{
    public partial class LogWork
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public TimeSpan WorkingTime { get; set; }
        public DateTime WorkingDate { get; set; }
        public TimeSpan StartWorkingTime { get; set; }
        public TimeSpan EndWorkingTime { get; set; }
        public bool? Deleted { get; set; }

        public virtual Employee Employee { get; set; }
    }
}

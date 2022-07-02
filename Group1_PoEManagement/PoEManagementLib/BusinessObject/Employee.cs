using System;
using System.Collections.Generic;

#nullable disable

namespace PoEManagementLib.BusinessObject
{
    public partial class Employee
    {
        public Employee()
        {
            Bonus = new HashSet<Bonus>();
            LogWorks = new HashSet<LogWork>();
        }

        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public decimal? Salary { get; set; }
        public int? LogWorkId { get; set; }
        public string Address { get; set; }
        public DateTime DoB { get; set; }
        public bool? Deleted { get; set; }
        public string Name { get; set; }

        public virtual Department Department { get; set; }
        public virtual Account Account { get; set; }
        public virtual ICollection<Bonus> Bonus { get; set; }
        public virtual ICollection<LogWork> LogWorks { get; set; }
    }
}

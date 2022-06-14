using System;
using System.Collections.Generic;

#nullable disable

namespace PoEManagementLib.BusinessObject
{
    public partial class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public string Location { get; set; }
        public bool? Deleted { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}

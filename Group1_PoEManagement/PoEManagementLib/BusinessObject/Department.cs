using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage = "DepartmentName is required!"), MinLength(2, ErrorMessage = "Minimum length is 2!")
        , MaxLength(100, ErrorMessage = "Maximum length is 100!")]
        public string DepartmentName { get; set; }
        [Required(ErrorMessage = "Location is required!"), MinLength(2, ErrorMessage = "Minimum length is 2!")
        , MaxLength(100, ErrorMessage = "Maximum length is 100!")]
        public string Location { get; set; }
        public bool? Deleted { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}

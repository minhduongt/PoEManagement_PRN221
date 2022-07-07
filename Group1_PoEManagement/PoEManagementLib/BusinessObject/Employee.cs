using PoEManagementLib.BusinessObject.MyValidation;
using PoEManagementLib.BusinessObject.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PoEManagementLib.BusinessObject
{
    public partial class Employee
    {
      
        
        public int Id { get; set; }
        [Required(ErrorMessage = "DepartmentId is required")]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Salary is required")]
        [Range(0, 9999999, ErrorMessage = "Salary is between 0 and 9999999")]
        public decimal? Salary { get; set; }
        [Required(ErrorMessage = "Address is required!"), MinLength(2, ErrorMessage = "Minimum length is 2!")
         , MaxLength(100, ErrorMessage = "Maximum length is 100!")]
        public string Address { get; set; }
        [DobValidation]
        public DateTime DoB { get; set; }
        [Required(ErrorMessage = "Name is required!"), MinLength(2, ErrorMessage = "Minimum length is 2!")
        , MaxLength(50, ErrorMessage = "Maximum length is 50!")]
        public string Name { get; set; }
        public bool? Deleted { get; set; }
        public virtual Department Department { get; set; }
        public virtual Account Account { get; set; }
    }
}

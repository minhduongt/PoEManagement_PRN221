using PoEManagementLib.BusinessObject.MyValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PoEManagementLib.BusinessObject
{
    public partial class Candidate
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Address is required!"), MinLength(2, ErrorMessage = "Minimum length is 2!")
        , MaxLength(100, ErrorMessage = "Maximum length is 100!")]
        public string Address { get; set; }
        [DobValidation]
        public DateTime DoB { get; set; }
        public bool? Deleted { get; set; }
        [Required(ErrorMessage = "Name is required!"), MinLength(2, ErrorMessage = "Minimum length is 1!")
       , MaxLength(50, ErrorMessage = "Maximum length is 50!")]
        public string Name { get; set; }
        public int ApplicationId { get; set; }
    }
}

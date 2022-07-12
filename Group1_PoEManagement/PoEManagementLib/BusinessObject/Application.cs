using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PoEManagementLib.BusinessObject
{
    public partial class Application
    {
        [Required(ErrorMessage = "Email is required!")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Introduction is required!"), MinLength(2, ErrorMessage = "Minimum length is 2!")
        , MaxLength(50, ErrorMessage = "Maximum length is 50!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required!"), MinLength(2, ErrorMessage = "Minimum length is 2!")
        , MaxLength(50, ErrorMessage = "Maximum length is 50!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Cvimage is required!")]
        public string Cvimage { get; set; }
        [Required(ErrorMessage = "RecuitmentId is required!")]
        public int RecuitmentId { get; set; }
        [Required(ErrorMessage = "Status is required!")]
        public string Status { get; set; }

        public virtual Recuitment Recuitment { get; set; }
    }
}

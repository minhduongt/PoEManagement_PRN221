using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PoEManagementLib.BusinessObject
{
    public partial class Account
    {
        [Required(ErrorMessage = "ID is required!")]
        public int Id { get; set; }
        [EmailAddress,Required(ErrorMessage = "Email is required!"), MinLength(2, ErrorMessage = "Minimum length is 2!")
        , MaxLength(50, ErrorMessage = "Maximum length is 50!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required!"), MinLength(2, ErrorMessage = "Minimum length is 2!")]
        public string Password { get; set; }
        public bool? IsManager { get; set; }
        public bool? Deleted { get; set; }

        public virtual Employee IdNavigation { get; set; }
    }
}

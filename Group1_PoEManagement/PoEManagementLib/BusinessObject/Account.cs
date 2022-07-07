using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PoEManagementLib.BusinessObject
{
    public partial class Account
    {
        
        public int Id { get; set; }
        [EmailAddress,Required(ErrorMessage = "Email is required!"), MinLength(8, ErrorMessage = "Minimum length is 8!")
        , MaxLength(200, ErrorMessage = "Maximum length is 200!")]
        [RegularExpression("^[a-z][a-z0-9_\\.]{5,32}@[a-z0-9]{2,}(\\.[a-z0-9]{2,4}){1,2}$", ErrorMessage ="Email is not valid")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required!"), MinLength(6, ErrorMessage = "Minimum length is 6!"), MaxLength(50, ErrorMessage = "Maximum length is 50!")]
        public string Password { get; set; }
        public bool? IsManager { get; set; }
        public bool? Deleted { get; set; }

        public virtual Employee IdNavigation { get; set; }
    }
}

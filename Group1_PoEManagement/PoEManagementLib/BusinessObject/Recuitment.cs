using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PoEManagementLib.BusinessObject
{
    public partial class Recuitment
    {
        public Recuitment()
        {
            Applications = new HashSet<Application>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required!"), MinLength(2, ErrorMessage = "Minimum length is 2!")
        , MaxLength(100, ErrorMessage = "Maximum length is 100!")]
        public string Title { get; set; }
        [Range(1, 100, ErrorMessage = "Quantity is between 1 and 100")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Title is required!"), MinLength(1, ErrorMessage = "Minimum length is 1!")
        , MaxLength(500, ErrorMessage = "Maximum length is 500!")]
        public string Description { get; set; }
        public bool? Deleted { get; set; }

        public virtual ICollection<Application> Applications { get; set; }
    }
}

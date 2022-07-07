using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PoEManagementLib.BusinessObject
{
    public partial class Bonus
    {
        public int Id { get; set; }
        [Range(0, 9999999, ErrorMessage = "Money must between 0 and 9999999")]
        public decimal? BonusMoney { get; set; }
        public int Month { get; set; }
        [Required(ErrorMessage = "Id employee is required!")]
        public int EmployeeId { get; set; }
        [Range(0, 9999999, ErrorMessage = "Money must between 0 and 9999999")]
        public decimal? Fine { get; set; }
        public bool? Deleted { get; set; }

        public virtual Employee Employee { get; set; }
    }
}

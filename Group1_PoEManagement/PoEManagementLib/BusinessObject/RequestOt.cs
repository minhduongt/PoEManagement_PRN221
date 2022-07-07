using PoEManagementLib.BusinessObject.MyValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PoEManagementLib.BusinessObject
{
    public partial class RequestOt
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        [Range(1, 100, ErrorMessage = "Hour OT is between 1 and 100")]
        public int Totalhour { get; set; }
        [DayRequestValid]
        public DateTime DayRequest { get; set; }
        public bool? Deleted { get; set; }
    }
}

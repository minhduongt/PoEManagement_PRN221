using System;
using System.Collections.Generic;

#nullable disable

namespace PoEManagementLib.BusinessObject
{
    public partial class RequestOt
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int Totalhour { get; set; }
        public DateTime DayRequest { get; set; }
        public bool? Deleted { get; set; }
    }
}

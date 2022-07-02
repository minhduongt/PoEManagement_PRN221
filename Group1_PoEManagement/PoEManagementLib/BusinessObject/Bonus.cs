﻿using System;
using System.Collections.Generic;

#nullable disable

namespace PoEManagementLib.BusinessObject
{
    public partial class Bonus
    {
        public int Id { get; set; }
        public decimal? BonusMoney { get; set; }
        public int Month { get; set; }
        public string Description { get; set; }
        public int EmployeeId { get; set; }
        public decimal? Fine { get; set; }
        public bool? Deleted { get; set; }

        public virtual Employee Employee { get; set; }
    }
}

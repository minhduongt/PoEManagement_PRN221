using System;
using System.Collections.Generic;

#nullable disable

namespace PoEManagementLib.BusinessObject
{
    public partial class Candidate
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public DateTime DoB { get; set; }
        public bool? Deleted { get; set; }
        public string Name { get; set; }
        public int ApplicationId { get; set; }
    }
}

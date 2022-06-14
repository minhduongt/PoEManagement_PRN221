using System;
using System.Collections.Generic;

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
        public string Title { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public bool? Deleted { get; set; }

        public virtual ICollection<Application> Applications { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace PoEManagementLib.BusinessObject
{
    public partial class Application
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Cvimage { get; set; }
        public int RecuitmentId { get; set; }
        public string Staus { get; set; }

        public virtual Recuitment Recuitment { get; set; }
    }
}

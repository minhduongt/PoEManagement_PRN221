using System;
using System.Collections.Generic;

#nullable disable

namespace PoEManagementLib.BusinessObject
{
    public partial class Account
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool? IsManager { get; set; }
        public bool? Deleted { get; set; }

        public virtual Employee IdNavigation { get; set; }
    }
}

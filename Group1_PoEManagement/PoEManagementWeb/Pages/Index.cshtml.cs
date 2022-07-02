using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PoEManagementLib.BusinessObject;
using PoEManagementLib.DataAccess;

using Microsoft.AspNetCore.Http;

namespace PoEManagementWeb.Pages
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        private readonly Prn221DBContext _context;

        public IndexModel(Prn221DBContext context)
        {
            _context = context;

        }

        public IActionResult OnGet()
        {
            string LoginEmail = HttpContext.Session.GetString("LoginEmail");
            string ManagerEmail = HttpContext.Session.GetString("ManagerEmail");
            if (LoginEmail == null)
            {
                return RedirectToPage("/Login");
            }
            else if (LoginEmail != null && ManagerEmail == null)
                return Page();
            else
                return RedirectToPage("/Home");
        }
    }
}


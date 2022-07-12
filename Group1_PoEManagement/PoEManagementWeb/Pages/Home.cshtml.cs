using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PoEManagementLib.BusinessObject;

namespace PoEManagementWeb.Pages
{
    public class HomeModel : PageModel
    {


        public IActionResult OnGet()
        {
            string LoginEmail = HttpContext.Session.GetString("LoginEmail");
            string ManagerEmail = HttpContext.Session.GetString("ManagerEmail");
            if (ManagerEmail == null)
            {
                TempData["Error"] = "You are not allowed to access.";
                return RedirectToPage("/Index");
            }
            return Page();
        }
    }
}

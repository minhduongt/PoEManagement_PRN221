using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PoEManagementLib.BusinessObject;
using PoEManagementLib.DataAccess;
using PoEManagementLib.DataAccess.Repository;

namespace PoEManagementWeb.Pages.Aplications
{
    public class IndexModel : PageModel
    {
        IApplicationRepository applicationRepository = new ApplicationRepository();

        public List<Application> Application { get;set; }

        public async Task OnGetAsync()
        {
            string LoginEmail = HttpContext.Session.GetString("LoginEmail");
            string ManagerEmail = HttpContext.Session.GetString("ManagerEmail");
            if (LoginEmail == null)
            {
                TempData["Error"] = "Please login.";
                 RedirectToPage("/Login");
            }
            if (LoginEmail != null && ManagerEmail == null)
                 RedirectToPage("/Home");
            Application = applicationRepository.GetApplications().ToList();
        }
    }
}

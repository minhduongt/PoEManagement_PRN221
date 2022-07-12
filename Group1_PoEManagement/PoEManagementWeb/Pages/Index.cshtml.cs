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
using PoEManagementLib.DataAccess.Repository;

namespace PoEManagementWeb.Pages
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        IApplicationRepository applicationRepository = new ApplicationRepository();
        public List<Application> Application { get; set; }

        public IActionResult OnGet()
        {
            string LoginEmail = HttpContext.Session.GetString("LoginEmail");
            string ManagerEmail = HttpContext.Session.GetString("ManagerEmail");
            Application = applicationRepository.GetApplications().ToList();
            return Page();
        }
    }
}


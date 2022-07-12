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

namespace PoEManagementWeb.Pages
{
    public class MyApplications : PageModel
    {
        IAccountRepository accountRepository = new AccountRepository();
        IEmployeeRepository employeeRepository = new EmployeeRepository();
        IApplicationRepository applicationRepository = new ApplicationRepository();

        public List<Application> Applications { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            string LoginEmail = HttpContext.Session.GetString("LoginEmail");
            if (LoginEmail == null)
            {
                TempData["Error"] = "Please login.";
                return RedirectToPage("/Login");
            }
            Applications = applicationRepository.GetApplications().Where(a => a.Email == LoginEmail).ToList();
            return Page();
        }
    }
}

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

namespace PoEManagementWeb.Pages.Accounts
{
    public class MyProfileModel : PageModel
    {
        IAccountRepository accountRepository = new AccountRepository();
        IEmployeeRepository employeeRepository = new EmployeeRepository();

        public Account Account { get; set; }
        public Employee Employee { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            string LoginEmail = HttpContext.Session.GetString("LoginEmail");
            string ManagerEmail = HttpContext.Session.GetString("ManagerEmail");
            if (LoginEmail == null)
            {
                TempData["Error"] = "Please login.";
                return RedirectToPage("/Login");
            }
            Account = accountRepository.GetAccountByEmail(LoginEmail);
            Employee = employeeRepository.GetEmployeeByID(Account.Id);
            if (Account == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

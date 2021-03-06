using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PoEManagementLib.BusinessObject;
using PoEManagementLib.DataAccess;
using PoEManagementLib.DataAccess.Repository;

namespace PoEManagementWeb.Pages.Accounts
{
    public class EditModel : PageModel
    {
        IAccountRepository accountRepository = new AccountRepository();
        IEmployeeRepository employeeRepository = new EmployeeRepository();

        [BindProperty]
        public Account Account { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            string LoginEmail = HttpContext.Session.GetString("LoginEmail");
            string ManagerEmail = HttpContext.Session.GetString("ManagerEmail");
            if (LoginEmail == null)
            {
                TempData["Error"] = "Please login.";
                return RedirectToPage("/Login");
            }
            if (LoginEmail != null && ManagerEmail == null)
                return RedirectToPage("/Home");

            if (id == null)
            {
                return NotFound();
            }

            Account = accountRepository.GetAccountByID(id);

            if (Account == null)
            {
                return NotFound();
            }
           ViewData["Id"] = new SelectList(employeeRepository.GetEmployees(), "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            ViewData["Id"] = new SelectList(employeeRepository.GetEmployees(), "Id", "Name");
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                accountRepository.UpdateAccount(Account);
            }
            catch (DbUpdateConcurrencyException)
            {
               
            }

            return RedirectToPage("./Index");
        }

        private bool AccountExists(int id)
        {
            return accountRepository.GetAccounts().Any(e => e.Id == id);
        }
    }
}

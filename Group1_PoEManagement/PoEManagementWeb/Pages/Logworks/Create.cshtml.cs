using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PoEManagementLib.BusinessObject;
using PoEManagementLib.DataAccess;
using PoEManagementLib.DataAccess.Repository;

namespace PoEManagementWeb.Pages.Logworks
{
    public class CreateModel : PageModel
    {
        ILogWorkRepository logWorkRepository = new LogWorkRepository();
        IEmployeeRepository employeeRepository = new EmployeeRepository();

        public IActionResult OnGet()
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

            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Address");
            return Page();
        }

        [BindProperty]
        public LogWork LogWork { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.LogWorks.Add(LogWork);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

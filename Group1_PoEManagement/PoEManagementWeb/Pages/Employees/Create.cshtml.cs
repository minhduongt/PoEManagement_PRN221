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

namespace PoEManagementWeb.Pages.Employees
{
    public class CreateModel : PageModel
    {
        IEmployeeRepository employeeRepository = new EmployeeRepository();
        IDepartmentRepository departmentRepository = new DepartmentRepository();

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

            ViewData["DepartmentId"] = new SelectList(departmentRepository.GetDepartments(), "Id", "DepartmentName");
            return Page();
        }

        [BindProperty]
        public Employee Employee { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            ViewData["DepartmentId"] = new SelectList(departmentRepository.GetDepartments(), "Id", "DepartmentName");
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (DateTime.Now.Year - Employee.DoB.Year < 20 || DateTime.Now.Year - Employee.DoB.Year > 65)
            {
                TempData["Error"] = "Must be more than 20 years old or less 65 years old";
                return Page();
            }
            employeeRepository.InsertEmployee(Employee);

            return RedirectToPage("./Index");
        }
    }
}

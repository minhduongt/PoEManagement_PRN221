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

namespace PoEManagementWeb.Pages.Employees
{
    public class EditModel : PageModel
    {
        IEmployeeRepository employeeRepository = new EmployeeRepository();
        IDepartmentRepository departmentRepository = new DepartmentRepository();
        [BindProperty]
        public Employee Employee { get; set; }

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

            Employee = employeeRepository.GetEmployeeByID(id);

            if (Employee == null)
            {
                return NotFound();
            }
           ViewData["DepartmentId"] = new SelectList(departmentRepository.GetDepartments(), "Id", "DepartmentName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            employeeRepository.UpdateEmployee(Employee);

            return RedirectToPage("./Index");
        }

        
    }
}

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

namespace PoEManagementWeb.Pages.RequestOts
{
    public class EditModel : PageModel
    {
        IRequestOtRepository requestOtRepository = new RequestOtRepository();
        IEmployeeRepository employeeRepository = new EmployeeRepository();
        [BindProperty]
        public RequestOt RequestOt { get; set; }

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
            ViewData["EmployeeId"] = new SelectList(employeeRepository.GetEmployees(), "Id", "Address");
            RequestOt = requestOtRepository.GetRequestOtByID(id);

            if (RequestOt == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            ViewData["EmployeeId"] = new SelectList(employeeRepository.GetEmployees(), "Id", "Address");
            if (!ModelState.IsValid)
            {
                return Page();
            }

            requestOtRepository.UpdateRequestOt(RequestOt);

            return RedirectToPage("./Index");
        }

    }
}

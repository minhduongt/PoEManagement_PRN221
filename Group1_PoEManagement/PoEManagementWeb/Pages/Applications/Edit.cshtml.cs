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

namespace PoEManagementWeb.Pages.Applications
{
    public class EditModel : PageModel
    {
        IApplicationRepository applicationRepository = new ApplicationRepository();
        IRecuitmentRepository recuitmentRepository = new RecuitmentRepository();

        [BindProperty]
        public Application Application { get; set; }

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

            Application = applicationRepository.GetApplicationByID(id);

            if (Application == null)
            {
                return NotFound();
            }
           ViewData["RecuitmentId"] = new SelectList(recuitmentRepository.GetRecuitments(), "Id", "Title");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            ViewData["RecuitmentId"] = new SelectList(recuitmentRepository.GetRecuitments(), "Id", "Title");
            if (!ModelState.IsValid)
            {
                return Page();
            }

            applicationRepository.UpdateApplication(Application);

            return RedirectToPage("./Index");
        }

    }
}

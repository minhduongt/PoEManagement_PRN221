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

namespace PoEManagementWeb.Pages.Applications
{
    public class CreateModel : PageModel
    {
        IApplicationRepository applicationRepository = new ApplicationRepository();
        IRecuitmentRepository recuitmentRepository = new RecuitmentRepository();
        public IActionResult OnGet(string RecuitmentId)
        {
            string LoginEmail = HttpContext.Session.GetString("LoginEmail");
            string ManagerEmail = HttpContext.Session.GetString("ManagerEmail");
            if (LoginEmail == null)
            {
                TempData["Error"] = "Please login.";
                return RedirectToPage("/Login");
            }
            //ViewData["RecuitmentId"] = new SelectList(recuitmentRepository.GetRecuitments(), "Id", "Title");
            TempData["RecuitmentId"] = RecuitmentId;
            return Page();
        }

        [BindProperty]
        public Application Application { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            //ViewData["RecuitmentId"] = new SelectList(recuitmentRepository.GetRecuitments(), "Id", "Title");
            if (!ModelState.IsValid)
            {
                return Page();
            }

            applicationRepository.InsertApplication(Application);

            return RedirectToPage("./Index");
        }
    }
}

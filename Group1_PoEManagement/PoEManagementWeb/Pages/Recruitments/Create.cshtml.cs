using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PoEManagementLib.BusinessObject;
using PoEManagementLib.DataAccess;
using PoEManagementLib.DataAccess.Repository;

namespace PoEManagementWeb.Pages.Recruitments
{
    public class CreateModel : PageModel
    {
        IRecuitmentRepository recuitmentRepository = new RecuitmentRepository();
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Recuitment Recuitment { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            recuitmentRepository.InsertRecuitment(Recuitment);

            return RedirectToPage("./Index");
        }
    }
}

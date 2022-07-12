using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PoEManagementLib.BusinessObject;
using PoEManagementLib.DataAccess;
using PoEManagementLib.DataAccess.Repository;

namespace PoEManagementWeb.Pages.Recruitments
{
    public class EditModel : PageModel
    {
        IRecuitmentRepository recuitmentRepository = new RecuitmentRepository();

        [BindProperty]
        public Recuitment Recuitment { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Recuitment = recuitmentRepository.GetRecuitmentByID(id);

            if (Recuitment == null)
            {
                return NotFound();
            }
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

            recuitmentRepository.UpdateRecuitment(Recuitment);

            return RedirectToPage("./Index");
        }

    }
}

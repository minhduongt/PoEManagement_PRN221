using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PoEManagementLib.BusinessObject;
using PoEManagementLib.DataAccess;
using PoEManagementLib.DataAccess.Repository;

namespace PoEManagementWeb.Pages.Recruitments
{
    public class DeleteModel : PageModel
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

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            recuitmentRepository.DeleteRecuitment(id);

            return RedirectToPage("./Index");
        }
    }
}

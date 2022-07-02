using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PoEManagementLib.BusinessObject;
using PoEManagementLib.DataAccess;

namespace PoEManagementWeb.Pages.Recruitments
{
    public class DeleteModel : PageModel
    {
        private readonly PoEManagementLib.DataAccess.Prn221DBContext _context;

        public DeleteModel(PoEManagementLib.DataAccess.Prn221DBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Recuitment Recuitment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Recuitment = await _context.Recuitments.FirstOrDefaultAsync(m => m.Id == id);

            if (Recuitment == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Recuitment = await _context.Recuitments.FindAsync(id);

            if (Recuitment != null)
            {
                _context.Recuitments.Remove(Recuitment);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

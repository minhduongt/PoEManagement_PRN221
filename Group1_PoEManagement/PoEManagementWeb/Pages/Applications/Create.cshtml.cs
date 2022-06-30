using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PoEManagementLib.BusinessObject;
using PoEManagementLib.DataAccess;

namespace PoEManagementWeb.Pages.Applications
{
    public class CreateModel : PageModel
    {
        private readonly PoEManagementLib.DataAccess.Prn221DBContext _context;

        public CreateModel(PoEManagementLib.DataAccess.Prn221DBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["RecuitmentId"] = new SelectList(_context.Recuitments, "Id", "Title");
            return Page();
        }

        [BindProperty]
        public Application Application { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Applications.Add(Application);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

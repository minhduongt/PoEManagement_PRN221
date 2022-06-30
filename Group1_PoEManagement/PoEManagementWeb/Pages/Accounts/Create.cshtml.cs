using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PoEManagementLib.BusinessObject;
using PoEManagementLib.DataAccess;

namespace PoEManagementWeb.Pages.Accounts
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
        ViewData["Id"] = new SelectList(_context.Employees, "Id", "Address");
            return Page();
        }

        [BindProperty]
        public Account Account { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Accounts.Add(Account);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

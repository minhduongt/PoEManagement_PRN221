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

namespace PoEManagementWeb.Pages.Accounts
{
    public class EditModel : PageModel
    {
        private readonly PoEManagementLib.DataAccess.Prn221DBContext _context;

        public EditModel(PoEManagementLib.DataAccess.Prn221DBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Account Account { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Account = await _context.Accounts
                .Include(a => a.IdNavigation).FirstOrDefaultAsync(m => m.Id == id);

            if (Account == null)
            {
                return NotFound();
            }
           ViewData["Id"] = new SelectList(_context.Employees, "Id", "Address");
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

            _context.Attach(Account).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(Account.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AccountExists(int id)
        {
            return _context.Accounts.Any(e => e.Id == id);
        }
    }
}

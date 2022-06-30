﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PoEManagementLib.BusinessObject;
using PoEManagementLib.DataAccess;

namespace PoEManagementWeb.Pages.Applications
{
    public class DeleteModel : PageModel
    {
        private readonly PoEManagementLib.DataAccess.Prn221DBContext _context;

        public DeleteModel(PoEManagementLib.DataAccess.Prn221DBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Application Application { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Application = await _context.Applications
                .Include(a => a.Recuitment).FirstOrDefaultAsync(m => m.Id == id);

            if (Application == null)
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

            Application = await _context.Applications.FindAsync(id);

            if (Application != null)
            {
                _context.Applications.Remove(Application);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
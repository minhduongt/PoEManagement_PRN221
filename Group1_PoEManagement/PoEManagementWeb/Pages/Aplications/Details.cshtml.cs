﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PoEManagementLib.BusinessObject;
using PoEManagementLib.DataAccess;

namespace PoEManagementWeb.Pages.Aplications
{
    public class DetailsModel : PageModel
    {
        private readonly PoEManagementLib.DataAccess.Prn221DBContext _context;

        public DetailsModel(PoEManagementLib.DataAccess.Prn221DBContext context)
        {
            _context = context;
        }

        public Application Application { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
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

            Application = await _context.Applications
                .Include(a => a.Recuitment).FirstOrDefaultAsync(m => m.Id == id);

            if (Application == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

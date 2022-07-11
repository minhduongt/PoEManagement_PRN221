using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PoEManagementLib.BusinessObject;
using PoEManagementLib.DataAccess;
using PoEManagementLib.DataAccess.Repository;

namespace PoEManagementWeb.Pages.Bonuses
{
    public class DetailsModel : PageModel
    {
        IBonusRepository bonusRepository = new BonusRepository();

        public Bonus Bonus { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
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

            Bonus = bonusRepository.GetBonusByID(id);

            if (Bonus == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

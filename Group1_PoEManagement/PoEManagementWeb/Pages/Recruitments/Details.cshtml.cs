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
    public class DetailsModel : PageModel
    {
        IRecuitmentRepository recuitmentRepository = new RecuitmentRepository();

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
    }
}

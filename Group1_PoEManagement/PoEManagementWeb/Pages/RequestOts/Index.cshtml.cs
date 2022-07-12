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

namespace PoEManagementWeb.Pages.RequestOts
{
    public class IndexModel : PageModel
    {
        IRequestOtRepository requestOtRepository = new RequestOtRepository();

        public IList<RequestOt> RequestOt { get;set; }

        public async Task OnGetAsync()
        {
            string LoginEmail = HttpContext.Session.GetString("LoginEmail");
            string ManagerEmail = HttpContext.Session.GetString("ManagerEmail");
            if (LoginEmail == null)
            {
                TempData["Error"] = "Please login.";
                 RedirectToPage("/Login");
            }
            if (LoginEmail != null && ManagerEmail == null)
                 RedirectToPage("/Home");

            RequestOt = requestOtRepository.GetRequestOts().Where(a => a.Deleted != true).ToList();
        }
    }
}

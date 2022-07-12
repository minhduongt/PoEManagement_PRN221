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

namespace PoEManagementWeb.Pages.Accounts
{
    public class IndexModel : PageModel
    {
        IAccountRepository accountRepository = new AccountRepository();
        public List<Account> Account { get;set; }
        public int pageNumber { get; set; }


        public async Task OnGetAsync()
        {
            pageNumber = 0;
            string LoginEmail = HttpContext.Session.GetString("LoginEmail");
            string ManagerEmail = HttpContext.Session.GetString("ManagerEmail");
            if (LoginEmail == null)
            {
                TempData["Error"] = "Please login.";
                RedirectToPage("/Login");
            }
            if (LoginEmail != null && ManagerEmail == null)
                RedirectToPage("/Home");

            Account = accountRepository.GetAccounts().Where(a => a.Deleted != true).ToList();
            var pageIndex = pageNumber;
            if (pageIndex == 0) TempData["PreDisabled"] = "disabled";
            if ((pageIndex * 10 + 10) < Account.Count()) Account = Account.GetRange(pageIndex * 10, 10);
            else
            {
                TempData["NextDisabled"] = "disabled";
                Account = Account.GetRange((pageIndex) * 10, Account.Count() - (pageIndex) * 10);
            }
            TempData["PageIndex"] = pageIndex;
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PoEManagementLib.BusinessObject;
using PoEManagementLib.DataAccess;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using PoEManagementLib.DataAccess.Repository;

namespace PoEManagementWeb.Pages
{
    [BindProperties]
    public class LoginModel : PageModel
    {
        private readonly IConfiguration _configuration;
        IAccountRepository accountRepository = new AccountRepository();
        public Account Account { get; set; }
        public IList<Account> AccountList { get; set; }
        public LoginModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult OnGet(string Message)
        {
            //if(Message != null)
            //    TempData["Error"] = "Login or Register to apply for job";
            return Page();
        }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
            AccountList = accountRepository.GetAccounts().ToList();
            Account loginUser;
            string managerEmail = _configuration["ManagerAccount:Email"];
            string managerPassword = _configuration["ManagerAccount:Password"];
            loginUser = AccountList.FirstOrDefault(account => account.Email.Equals(Account.Email) && account.Password.Equals(Account.Password));
            if (Account.Email.Equals(managerEmail) && Account.Password.Equals(managerPassword))
            {
                HttpContext.Session.SetString("LoginEmail", Account.Email);
                HttpContext.Session.SetString("ManagerEmail", managerEmail);
                return RedirectToPage("/Home");
            }

            else if (loginUser != null)
            {
                HttpContext.Session.SetString("LoginEmail", Account.Email);
                if(loginUser.IsManager == true)
                    HttpContext.Session.SetString("ManagerEmail", Account.Email);
                else
                {
                    return RedirectToPage("/Index");
                }
               
            }
            else
            {
                TempData["InputEmail"] = Account.Email;
                TempData["Error"] = "Login failed! Check your username or password.";
                
            }
            return Page();
        }

        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Clear();
            return Page();
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PoEManagementLib.BusinessObject;
using PoEManagementLib.DataAccess.Repository;

namespace PoEManagementWeb.Pages
{
    [BindProperties]
    public class RegisterModel : PageModel
    {
        public Account Account { get; set; }
        public IList<Account> AccountList { get; set; }
        IAccountRepository accountRepository = new AccountRepository();
        public string GenerateId()
        {
            Random res = new Random();
            // String of alphabets 
            string str = "abcdefghijklmnopqrstuvwxyz";
            int size = 6;
            // Initializing the empty string
            string ran = "";
            for (int i = 0; i < size; i++)
            {
                // Selecting an index randomly
                int x = res.Next(26);
                // Appending the character at the 
                // index to the random string.
                ran = ran + str[x];
            }
            return ran;
        }

        public IActionResult OnGet()
        {
            AccountList = accountRepository.GetAccounts().ToList();
            string randomId = GenerateId().ToUpper();
            while(AccountList.FirstOrDefault(acc=> acc.Id.Equals(randomId)) != null)
            {
                randomId = GenerateId().ToUpper();
            }
            TempData["Id"] = randomId;
            return Page();
        }

       

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Account checkAccount = accountRepository.GetAccountByEmail(Account.Email);
            if(checkAccount != null)
            {
                TempData["Error"] = "This email is existed";
                return Page();
            }
            accountRepository.InsertAccount(Account);

            return RedirectToPage("./Login");
        }
    }
}

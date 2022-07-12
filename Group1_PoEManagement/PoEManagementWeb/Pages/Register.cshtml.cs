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
        public Employee Employee { get; set; }
        public IList<Account> AccountList { get; set; }
        public IList<Employee> EmployeeList { get; set; }
        IAccountRepository accountRepository = new AccountRepository();
        IEmployeeRepository employeeRepository = new EmployeeRepository();
        //public string GenerateId()
        //{
        //    Random res = new Random();
        //    // String of alphabets 
        //    string str = "abcdefghijklmnopqrstuvwxyz";
        //    int size = 6;
        //    // Initializing the empty string
        //    string ran = "";
        //    for (int i = 0; i < size; i++)
        //    {
        //        // Selecting an index randomly
        //        int x = res.Next(26);
        //        // Appending the character at the 
        //        // index to the random string.
        //        ran = ran + str[x];
        //    }
        //    return ran;
        //}

        public IActionResult OnGet()
        {
            
            return Page();
        }

       

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {

            Employee.Id = DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Minute + DateTime.Now.Millisecond;
            EmployeeList = employeeRepository.GetEmployees().ToList();
            //Employee checkEmp = employeeRepository.GetEmployeeByID(Employee.Id);
            //if (checkEmp != null)
            //{
            //    TempData["Error"] = "There is an employee is existed";
            //    return Page();
            //}
            //foreach(var emp in EmployeeList)
            //{
            //    if (emp.Id == Employee.Id)
            //        Employee.Id += 1;
            //}
            Employee.Salary = 0;
            Employee.DepartmentId= 1;
            if(DateTime.Now.Year - Employee.DoB.Year < 20 || DateTime.Now.Year - Employee.DoB.Year > 65)
            {
                TempData["Error"] = "Must be more than 20 years old or less 65 years old";
                return Page();
            }
            employeeRepository.InsertEmployee(Employee);
            AccountList = accountRepository.GetAccounts().ToList();
            Account.Id = Employee.Id;
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

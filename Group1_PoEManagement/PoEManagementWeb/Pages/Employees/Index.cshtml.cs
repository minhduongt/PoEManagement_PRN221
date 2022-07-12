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

namespace PoEManagementWeb.Pages.Employees
{
    public class IndexModel : PageModel
    {
        IEmployeeRepository employeeRepository = new EmployeeRepository();

        public List<Employee> Employee { get;set; }
        public int pageNumber { get; set; }

        public void OnGet()
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
            Employee = employeeRepository.GetEmployees().Where(a => a.Deleted != true).ToList();
            //Paging
            var pageIndex = pageNumber;
            if (pageIndex == 0) TempData["PreDisabled"] = "disabled";
            if ((pageIndex * 10 + 10) < Employee.Count()) Employee = Employee.GetRange(pageIndex * 10, 10);
            else
            {
                TempData["NextDisabled"] = "disabled";
                Employee = Employee.GetRange((pageIndex) * 10, Employee.Count() - (pageIndex) * 10);
            }
            TempData["PageIndex"] = pageIndex;

        }
    }
}

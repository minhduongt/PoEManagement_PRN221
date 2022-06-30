using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PoEManagementLib.BusinessObject;
using PoEManagementLib.DataAccess;

namespace PoEManagementWeb.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly PoEManagementLib.DataAccess.Prn221DBContext _context;

        public IndexModel(PoEManagementLib.DataAccess.Prn221DBContext context)
        {
            _context = context;
        }

        public IList<Employee> Employee { get;set; }

        public async Task OnGetAsync()
        {
            Employee = await _context.Employees
                .Include(e => e.Department).ToListAsync();
        }
    }
}

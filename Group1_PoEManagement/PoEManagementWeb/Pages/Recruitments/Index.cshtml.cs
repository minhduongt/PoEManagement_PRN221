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
    public class IndexModel : PageModel
    {
        IRecuitmentRepository recuitmentRepository = new RecuitmentRepository();

        public IList<Recuitment> Recuitment { get;set; }

        public async Task OnGetAsync()
        {
            Recuitment = recuitmentRepository.GetRecuitments().Where(a => a.Deleted != true).ToList();
        }
    }
}

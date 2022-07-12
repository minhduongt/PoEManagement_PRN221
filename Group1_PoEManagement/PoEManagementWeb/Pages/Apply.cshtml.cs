using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PoEManagementLib.BusinessObject;
using PoEManagementLib.DataAccess;
using PoEManagementLib.DataAccess.Repository;

namespace PoEManagementWeb.Pages.Apply
{
    [BindProperties]
    public class ApplyModel : PageModel
    {
        IApplicationRepository applicationRepository = new ApplicationRepository();
        IRecuitmentRepository recuitmentRepository = new RecuitmentRepository();
        ICandidateRepository candidateRepository = new CandidateRepository();
        public IActionResult OnGet(string RecuitmentId)
        {
            string ManagerEmail = HttpContext.Session.GetString("ManagerEmail");
            if (ManagerEmail != null)
            {
                TempData["Error"] = "Manager cannot apply";
                return RedirectToPage("/Index");
            }
            //ViewData["RecuitmentId"] = new SelectList(recuitmentRepository.GetRecuitments(), "Id", "Title");
            Recuitment recuit =  recuitmentRepository.GetRecuitmentByID(int.Parse(RecuitmentId));
            TempData["RecuitmentId"] = RecuitmentId;
            TempData["RecuitmentTitle"] = recuit.Title;
            return Page();
        }

       
        public Application Application { get; set; }
        public Candidate Candidate { get; set; }
        public List<Application> ApplicationList { get; set; }
        public List<Candidate> CandidateList { get; set; }
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            //ViewData["RecuitmentId"] = new SelectList(recuitmentRepository.GetRecuitments(), "Id", "Title");
            ApplicationList = applicationRepository.GetApplications().ToList();
            CandidateList = candidateRepository.GetCandidates().ToList();
            Candidate.Id = 1;
            Application.Id = 1;
            foreach(Application app in ApplicationList)
            {
                if (app.Id == Application.Id)
                    Application.Id += 1;
            }
            foreach (Candidate can in CandidateList)
            {
                if (can.Id == Candidate.Id)
                    Candidate.Id += 1;
            }
            Application.Status = "Pending";
            applicationRepository.InsertApplication(Application);
            Candidate.ApplicationId = Application.Id;
            candidateRepository.InsertCandidate(Candidate);

            

            return RedirectToPage("./Index");
        }
    }
}

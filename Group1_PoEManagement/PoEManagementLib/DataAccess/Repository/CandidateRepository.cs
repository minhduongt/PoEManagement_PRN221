using PoEManagementLib.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoEManagementLib.DataAccess.Repository
{
    public class CandidateRepository : ICandidateRepository
    {
        public Candidate GetCandidateByID(int candidateId) => CandidateDAO.Instance.GetCandidateByID(candidateId);
        public IEnumerable<Candidate> GetCandidates() => CandidateDAO.Instance.GetCandidateList();
        public void InsertCandidate(Candidate candidate) => CandidateDAO.Instance.AddNew(candidate);
        public void DeleteCandidate(int candidateId) => CandidateDAO.Instance.Remove(candidateId);
        public void UpdateCandidate(Candidate candidate) => CandidateDAO.Instance.Update(candidate);
    }
}

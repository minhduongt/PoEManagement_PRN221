using PoEManagementLib.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoEManagementLib.DataAccess.Repository
{
    public interface ICandidateRepository
    {
        IEnumerable<Candidate> GetCandidates();
        Candidate GetCandidateByID(int candidateId);
        void InsertCandidate(Candidate candidate);
        void DeleteCandidate(int candidateId);
        void UpdateCandidate(Candidate candidate);
    }
}

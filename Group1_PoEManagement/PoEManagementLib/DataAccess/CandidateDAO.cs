using PoEManagementLib.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoEManagementLib.DataAccess
{
    public class CandidateDAO
    {
        private static CandidateDAO instance = null;
        private static readonly object instanceLock = new object();
        public static CandidateDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CandidateDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Candidate> GetCandidateList()
        {
            var candidates = new List<Candidate>();
            try
            {
                using var context = new Prn221DBContext();
                candidates = context.Candidates.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return candidates;
        }

        public Candidate GetCandidateByID(int candidateId)
        {
            Candidate candidate = null;
            try
            {
                using var context = new Prn221DBContext();
                candidate = context.Candidates.SingleOrDefault(c => c.Id.Equals(candidateId));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return candidate;
        }


        public void AddNew(Candidate candidate)
        {
            try
            {
                Candidate _candidate = GetCandidateByID(candidate.Id);
                if (_candidate == null)
                {
                    using var context = new Prn221DBContext();
                    context.Candidates.Add(candidate);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The candidate is exist.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Candidate candidate)
        {
            try
            {
                Candidate _candidate = GetCandidateByID(candidate.Id);
                if (_candidate != null)
                {
                    using var context = new Prn221DBContext();
                    context.Candidates.Update(candidate);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The candidate does not exist.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(int candidateId)
        {
            try
            {
                Candidate candidate = GetCandidateByID(candidateId);
                if (candidate != null)
                {
                    using var context = new Prn221DBContext();
                    context.Candidates.Remove(candidate);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The candidate does not exist.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}


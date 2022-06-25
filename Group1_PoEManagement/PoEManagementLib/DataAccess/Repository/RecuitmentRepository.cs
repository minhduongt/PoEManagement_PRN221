using PoEManagementLib.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoEManagementLib.DataAccess.Repository
{
    public class RecuitmentRepository :IRecuitmentRepository
    {
        public Recuitment GetRecuitmentByID(int recuitmentId) => RecuitmentDAO.Instance.GetRecuitmentByID(recuitmentId);
        public IEnumerable<Recuitment> GetRecuitments() => RecuitmentDAO.Instance.GetRecuitmentList();
        public void InsertRecuitment(Recuitment recuitment) => RecuitmentDAO.Instance.AddNew(recuitment);
        public void DeleteRecuitment(int recuitmentId) => RecuitmentDAO.Instance.Remove(recuitmentId);
        public void UpdateRecuitment(Recuitment recuitment) => RecuitmentDAO.Instance.Update(recuitment);
    }
}

using PoEManagementLib.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoEManagementLib.DataAccess.Repository
{
    public interface IRecuitmentRepository
    {
        IEnumerable<Recuitment> GetRecuitments();
        Recuitment GetRecuitmentByID(int recuitmentId);
        void InsertRecuitment(Recuitment recuitment);
        void DeleteRecuitment(int recuitmentId);
        void UpdateRecuitment(Recuitment recuitment);
    }
}

using PoEManagementLib.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoEManagementLib.DataAccess.Repository
{
    public interface IRequestOtRepository
    {
        IEnumerable<RequestOt> GetRequestOts();
        RequestOt GetRequestOtByID(int requestOtId);
        void InsertRequestOt(RequestOt requestOt);
        void DeleteRequestOt(int requestOtId);
        void UpdateRequestOt(RequestOt requestOt);
    }
}

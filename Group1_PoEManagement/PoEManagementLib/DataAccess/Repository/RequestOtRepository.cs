using PoEManagementLib.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoEManagementLib.DataAccess.Repository
{
    public class RequestOtRepository :IRequestOtRepository
    {
        public RequestOt GetRequestOtByID(int requestOtId) => RequestOtDAO.Instance.GetRequestOtByID(requestOtId);
        public IEnumerable<RequestOt> GetRequestOts() => RequestOtDAO.Instance.GetRequestOtList();
        public void InsertRequestOt(RequestOt requestOt) => RequestOtDAO.Instance.AddNew(requestOt);
        public void DeleteRequestOt(int requestOtId) => RequestOtDAO.Instance.Remove(requestOtId);
        public void UpdateRequestOt(RequestOt requestOt) => RequestOtDAO.Instance.Update(requestOt);
    }
}

using PoEManagementLib.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoEManagementLib.DataAccess.Repository
{
    public class ApplicationRepository :IApplicationRepository
    {
        public Application GetApplicationByID(int applicationId) => ApplicationDAO.Instance.GetApplicationByID(applicationId);
        public IEnumerable<Application> GetApplications() => ApplicationDAO.Instance.GetApplicationList();
        public void InsertApplication(Application application) => ApplicationDAO.Instance.AddNew(application);
        public void DeleteApplication(int applicationId) => ApplicationDAO.Instance.Remove(applicationId);
        public void UpdateApplication(Application application) => ApplicationDAO.Instance.Update(application);
    }
}

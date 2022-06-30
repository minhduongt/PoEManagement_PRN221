using PoEManagementLib.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoEManagementLib.DataAccess.Repository
{
    public interface IApplicationRepository
    {
        IEnumerable<Application> GetApplications();
        Application GetApplicationByID(int applicationId);
        void InsertApplication(Application application);
        void DeleteApplication(int applicationId);
        void UpdateApplication(Application application);
    }
}

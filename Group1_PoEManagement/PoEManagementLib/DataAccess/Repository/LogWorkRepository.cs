using PoEManagementLib.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoEManagementLib.DataAccess.Repository
{
    public class LogWorkRepository :ILogWorkRepository
    {
        public LogWork GetLogWorkByID(int logWorkId) => LogWorkDAO.Instance.GetLogWorkByID(logWorkId);
        public IEnumerable<LogWork> GetLogWorks() => LogWorkDAO.Instance.GetLogWorkList();
        public void InsertLogWork(LogWork logWork) => LogWorkDAO.Instance.AddNew(logWork);
        public void DeleteLogWork(int logWorkId) => LogWorkDAO.Instance.Remove(logWorkId);
        public void UpdateLogWork(LogWork logWork) => LogWorkDAO.Instance.Update(logWork);
    }
}

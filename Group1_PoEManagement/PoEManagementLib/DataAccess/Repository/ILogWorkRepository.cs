using PoEManagementLib.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoEManagementLib.DataAccess.Repository
{
    public interface ILogWorkRepository
    {
        IEnumerable<LogWork> GetLogWorks();
        LogWork GetLogWorkByID(int logWorkId);
        void InsertLogWork(LogWork logWork);
        void DeleteLogWork(int logWorkId);
        void UpdateLogWork(LogWork logWork);
    }
}

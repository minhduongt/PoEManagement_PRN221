using PoEManagementLib.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoEManagementLib.DataAccess
{
    public class LogWorkDAO
    {
        //Using Singleton Pattern
        private static LogWorkDAO instance = null;
        private static readonly object instanceLock = new object();
        public static LogWorkDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new LogWorkDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<LogWork> GetLogWorkList()
        {
            var logWorks = new List<LogWork>();
            try
            {
                using var context = new Prn221DBContext();
                logWorks = context.LogWorks.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return logWorks;
        }

        public LogWork GetLogWorkByID(int logWorkId)
        {
            LogWork logWork = null;
            try
            {
                using var context = new Prn221DBContext();
                logWork = context.LogWorks.SingleOrDefault(c => c.Id.Equals(logWorkId));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return logWork;
        }


        public void AddNew(LogWork logWork)
        {
            try
            {
                LogWork _logWork = GetLogWorkByID(logWork.Id);
                if (_logWork == null)
                {
                    using var context = new Prn221DBContext();
                    context.LogWorks.Add(logWork);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The logWork is exist.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(LogWork logWork)
        {
            try
            {
                LogWork _logWork = GetLogWorkByID(logWork.Id);
                if (_logWork != null)
                {
                    using var context = new Prn221DBContext();
                    context.LogWorks.Update(logWork);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The logWork does not exist.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(int logWorkId)
        {
            try
            {
                LogWork logWork = GetLogWorkByID(logWorkId);
                if (logWork != null)
                {
                    using var context = new Prn221DBContext();
                    context.LogWorks.Remove(logWork);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The logWork does not exist.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

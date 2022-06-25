using PoEManagementLib.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoEManagementLib.DataAccess
{
    public class ApplicationDAO
    {
        //Using Singleton Pattern
        private static ApplicationDAO instance = null;
        private static readonly object instanceLock = new object();
        public static ApplicationDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ApplicationDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Application> GetApplicationList()
        {
            var accounts = new List<Application>();
            try
            {
                using var context = new Prn221DBContext();
                accounts = context.Applications.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return accounts;
        }

        public Application GetApplicationByID(int accountId)
        {
            Application account = null;
            try
            {
                using var context = new Prn221DBContext();
                account = context.Applications.SingleOrDefault(c => c.Id.Equals(accountId));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return account;
        }


        public void AddNew(Application account)
        {
            try
            {
                Application _account = GetApplicationByID(account.Id);
                if (_account == null)
                {
                    using var context = new Prn221DBContext();
                    context.Applications.Add(account);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The account is exist.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Application account)
        {
            try
            {
                Application _account = GetApplicationByID(account.Id);
                if (_account != null)
                {
                    using var context = new Prn221DBContext();
                    context.Applications.Update(account);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The account does not exist.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(int accountId)
        {
            try
            {
                Application account = GetApplicationByID(accountId);
                if (account != null)
                {
                    using var context = new Prn221DBContext();
                    context.Applications.Remove(account);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The account does not exist.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

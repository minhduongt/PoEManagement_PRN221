using PoEManagementLib.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoEManagementLib.DataAccess
{
    public class AccountDAO
    {
        //Using Singleton Pattern
        private static AccountDAO instance = null;
        private static readonly object instanceLock = new object();
        public static AccountDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new AccountDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Account> GetAccountList()
        {
            var accounts = new List<Account>();
            try
            {
                using var context = new Prn221DBContext();
                accounts = context.Accounts.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return accounts;
        }

        public Account GetAccountByID(int accountId)
        {
            Account account = null;
            try
            {
                using var context = new Prn221DBContext();
                account = context.Accounts.SingleOrDefault(c => c.Id.Equals(accountId));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return account;
        }

        public Account GetAccountByEmail(string email)
        {
            Account account = null;
            try
            {
                using var context = new Prn221DBContext();
                account = context.Accounts.SingleOrDefault(c => c.Email.Equals(email));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return account;
        }

        public Account CheckLogin(string email, string password)
        {
            Account account = null;
            try
            {
                using var context = new Prn221DBContext();
                account = context.Accounts.SingleOrDefault(c => c.Email.Equals(email) && c.Password.Equals(password));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return account;
        }


        public void AddNew(Account account)
        {
            try
            {
                Account _account = GetAccountByID(account.Id);
                if (_account == null)
                {
                    using var context = new Prn221DBContext();
                    context.Accounts.Add(account);
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

        public void Update(Account account)
        {
            try
            {
                Account _account = GetAccountByID(account.Id);
                if (_account != null)
                {
                    using var context = new Prn221DBContext();
                    context.Accounts.Update(account);
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
                Account account = GetAccountByID(accountId);
                if (account != null)
                {
                    using var context = new Prn221DBContext();
                    context.Accounts.Remove(account);
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

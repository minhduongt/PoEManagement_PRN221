using PoEManagementLib.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoEManagementLib.DataAccess.Repository
{
    public class AccountRepository :IAccountRepository
    {
        public Account GetAccountByID(int accountId) => AccountDAO.Instance.GetAccountByID(accountId);
        public Account GetAccountByEmail(string email) => AccountDAO.Instance.GetAccountByEmail(email);
        public IEnumerable<Account> GetAccounts() => AccountDAO.Instance.GetAccountList();
        public void InsertAccount(Account account) => AccountDAO.Instance.AddNew(account);
        public void DeleteAccount(int accountId) => AccountDAO.Instance.Remove(accountId);
        public void UpdateAccount(Account account) => AccountDAO.Instance.Update(account);
    }
}

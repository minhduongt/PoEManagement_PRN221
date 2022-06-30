using PoEManagementLib.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoEManagementLib.DataAccess.Repository
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAccounts();
        Account GetAccountByID(int accountId);
        Account GetAccountByEmail(string email);
        void InsertAccount(Account account);
        void DeleteAccount(int accountId);
        void UpdateAccount(Account account);
    }
}

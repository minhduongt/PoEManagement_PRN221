using PoEManagementLib.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoEManagementLib.DataAccess.Repository
{
    public interface IBonusRepository
    {
        IEnumerable<Bonus> GetBonuss();
        Bonus GetBonusByID(int bonusId);
        void InsertBonus(Bonus bonus);
        void DeleteBonus(int bonusId);
        void UpdateBonus(Bonus bonus);
    }
}

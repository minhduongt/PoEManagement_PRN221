using PoEManagementLib.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoEManagementLib.DataAccess.Repository
{
    public class BonusRepository: IBonusRepository
    {
        public Bonus GetBonusByID(int bonusId) => BonusDAO.Instance.GetBonusByID(bonusId);
        public IEnumerable<Bonus> GetBonuss() => BonusDAO.Instance.GetBonusList();
        public void InsertBonus(Bonus bonus) => BonusDAO.Instance.AddNew(bonus);
        public void DeleteBonus(int bonusId) => BonusDAO.Instance.Remove(bonusId);
        public void UpdateBonus(Bonus bonus) => BonusDAO.Instance.Update(bonus);
    }
}

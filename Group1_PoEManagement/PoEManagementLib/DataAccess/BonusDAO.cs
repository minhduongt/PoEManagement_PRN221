using PoEManagementLib.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoEManagementLib.DataAccess
{
    public class BonusDAO
    {
        //Using Singleton Pattern
        private static BonusDAO instance = null;
        private static readonly object instanceLock = new object();
        public static BonusDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new BonusDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Bonus> GetBonusList()
        {
            var bonuss = new List<Bonus>();
            try
            {
                using var context = new Prn221DBContext();
                bonuss = context.Bonus.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return bonuss;
        }

        public Bonus GetBonusByID(int bonusId)
        {
            Bonus bonus = null;
            try
            {
                using var context = new Prn221DBContext();
                bonus = context.Bonus.SingleOrDefault(c => c.Id.Equals(bonusId));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return bonus;
        }


        public void AddNew(Bonus bonus)
        {
            try
            {
                Bonus _bonus = GetBonusByID(bonus.Id);
                if (_bonus == null)
                {
                    using var context = new Prn221DBContext();
                    context.Bonus.Add(bonus);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The bonus is exist.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Bonus bonus)
        {
            try
            {
                Bonus _bonus = GetBonusByID(bonus.Id);
                if (_bonus != null)
                {
                    using var context = new Prn221DBContext();
                    context.Bonus.Update(bonus);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The bonus does not exist.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(int bonusId)
        {
            try
            {
                Bonus bonus = GetBonusByID(bonusId);
                if (bonus != null)
                {
                    using var context = new Prn221DBContext();
                    context.Bonus.Remove(bonus);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The bonus does not exist.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

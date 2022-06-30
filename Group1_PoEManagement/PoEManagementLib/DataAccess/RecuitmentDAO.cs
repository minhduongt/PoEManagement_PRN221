using PoEManagementLib.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoEManagementLib.DataAccess
{
    public class RecuitmentDAO
    {
        //Using Singleton Pattern
        private static RecuitmentDAO instance = null;
        private static readonly object instanceLock = new object();
        public static RecuitmentDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new RecuitmentDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Recuitment> GetRecuitmentList()
        {
            var recuitments = new List<Recuitment>();
            try
            {
                using var context = new Prn221DBContext();
                recuitments = context.Recuitments.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return recuitments;
        }

        public Recuitment GetRecuitmentByID(int recuitmentId)
        {
            Recuitment recuitment = null;
            try
            {
                using var context = new Prn221DBContext();
                recuitment = context.Recuitments.SingleOrDefault(c => c.Id.Equals(recuitmentId));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return recuitment;
        }


        public void AddNew(Recuitment recuitment)
        {
            try
            {
                Recuitment _recuitment = GetRecuitmentByID(recuitment.Id);
                if (_recuitment == null)
                {
                    using var context = new Prn221DBContext();
                    context.Recuitments.Add(recuitment);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The recuitment is exist.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Recuitment recuitment)
        {
            try
            {
                Recuitment _recuitment = GetRecuitmentByID(recuitment.Id);
                if (_recuitment != null)
                {
                    using var context = new Prn221DBContext();
                    context.Recuitments.Update(recuitment);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The recuitment does not exist.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(int recuitmentId)
        {
            try
            {
                Recuitment recuitment = GetRecuitmentByID(recuitmentId);
                if (recuitment != null)
                {
                    using var context = new Prn221DBContext();
                    context.Recuitments.Remove(recuitment);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The recuitment does not exist.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

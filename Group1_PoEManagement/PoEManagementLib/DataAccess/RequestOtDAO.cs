using PoEManagementLib.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoEManagementLib.DataAccess
{
    public class RequestOtDAO
    {
        private static RequestOtDAO instance = null;
        private static readonly object instanceLock = new object();
        public static RequestOtDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new RequestOtDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<RequestOt> GetRequestOtList()
        {
            var requestots = new List<RequestOt>();
            try
            {
                using var context = new Prn221DBContext();
                requestots = context.RequestOts.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return requestots;
        }

        public RequestOt GetRequestOtByID(int requestotId)
        {
            RequestOt requestot = null;
            try
            {
                using var context = new Prn221DBContext();
                requestot = context.RequestOts.SingleOrDefault(c => c.Id.Equals(requestotId));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return requestot;
        }


        public void AddNew(RequestOt requestot)
        {
            try
            {
                RequestOt _requestot = GetRequestOtByID(requestot.Id);
                if (_requestot == null)
                {
                    using var context = new Prn221DBContext();
                    context.RequestOts.Add(requestot);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The requestot is exist.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(RequestOt requestot)
        {
            try
            {
                RequestOt _requestot = GetRequestOtByID(requestot.Id);
                if (_requestot != null)
                {
                    using var context = new Prn221DBContext();
                    context.RequestOts.Update(requestot);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The requestot does not exist.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(int requestotId)
        {
            try
            {
                RequestOt requestot = GetRequestOtByID(requestotId);
                if (requestot != null)
                {
                    using var context = new Prn221DBContext();
                    context.RequestOts.Remove(requestot);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The requestot does not exist.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

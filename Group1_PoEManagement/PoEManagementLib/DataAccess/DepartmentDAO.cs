using PoEManagementLib.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoEManagementLib.DataAccess
{
    public class DepartmentDAO
    {
        private static DepartmentDAO instance = null;
        private static readonly object instanceLock = new object();
        public static DepartmentDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new DepartmentDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Department> GetDepartmentList()
        {
            var departments = new List<Department>();
            try
            {
                using var context = new Prn221DBContext();
                departments = context.Departments.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return departments;
        }

        public Department GetDepartmentByID(int departmentId)
        {
            Department department = null;
            try
            {
                using var context = new Prn221DBContext();
                department = context.Departments.SingleOrDefault(c => c.Id.Equals(departmentId));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return department;
        }


        public void AddNew(Department department)
        {
            try
            {
                Department _department = GetDepartmentByID(department.Id);
                if (_department == null)
                {
                    using var context = new Prn221DBContext();
                    context.Departments.Add(department);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The department is exist.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Department department)
        {
            try
            {
                Department _department = GetDepartmentByID(department.Id);
                if (_department != null)
                {
                    using var context = new Prn221DBContext();
                    context.Departments.Update(department);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The department does not exist.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(int departmentId)
        {
            try
            {
                Department department = GetDepartmentByID(departmentId);
                if (department != null)
                {
                    using var context = new Prn221DBContext();
                    context.Departments.Remove(department);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The department does not exist.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}


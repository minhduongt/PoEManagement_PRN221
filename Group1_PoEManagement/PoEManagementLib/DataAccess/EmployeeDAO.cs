using PoEManagementLib.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoEManagementLib.DataAccess
{
    public class EmployeeDAO
    {
        //Using Singleton Pattern
        private static EmployeeDAO instance = null;
        private static readonly object instanceLock = new object();
        public static EmployeeDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new EmployeeDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Employee> GetEmployeeList()
        {
            var employees = new List<Employee>();
            try
            {
                using var context = new Prn221DBContext();
                employees = context.Employees.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return employees;
        }

        public Employee GetEmployeeByID(int employeeId)
        {
            Employee employee = null;
            try
            {
                using var context = new Prn221DBContext();
                employee = context.Employees.SingleOrDefault(c => c.Id.Equals(employeeId));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return employee;
        }


        public void AddNew(Employee employee)
        {
            try
            {
                Employee _employee = GetEmployeeByID(employee.Id);
                if (_employee == null)
                {
                    using var context = new Prn221DBContext();
                    context.Employees.Add(employee);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The employee is exist.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Employee employee)
        {
            try
            {
                Employee _employee = GetEmployeeByID(employee.Id);
                if (_employee != null)
                {
                    using var context = new Prn221DBContext();
                    context.Employees.Update(employee);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The employee does not exist.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(int employeeId)
        {
            try
            {
                Employee employee = GetEmployeeByID(employeeId);
                if (employee != null)
                {
                    using var context = new Prn221DBContext();
                    context.Employees.Remove(employee);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The employee does not exist.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

using PoEManagementLib.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoEManagementLib.DataAccess.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public Employee GetEmployeeByID(int employeeId) => EmployeeDAO.Instance.GetEmployeeByID(employeeId);
        public IEnumerable<Employee> GetEmployees() => EmployeeDAO.Instance.GetEmployeeList();
        public void InsertEmployee(Employee employee) => EmployeeDAO.Instance.AddNew(employee);
        public void DeleteEmployee(int employeeId) => EmployeeDAO.Instance.Remove(employeeId);
        public void UpdateEmployee(Employee employee) => EmployeeDAO.Instance.Update(employee);
    }
}

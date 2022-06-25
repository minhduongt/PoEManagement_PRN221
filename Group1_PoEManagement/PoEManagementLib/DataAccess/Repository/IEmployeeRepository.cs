using PoEManagementLib.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoEManagementLib.DataAccess.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployeeByID(int employeeId);
        void InsertEmployee(Employee employee);
        void DeleteEmployee(int employeeId);
        void UpdateEmployee(Employee employee);
    }
}

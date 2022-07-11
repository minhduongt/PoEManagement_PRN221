using PoEManagementLib.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoEManagementLib.DataAccess.Repository
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetDepartments();
        Department GetDepartmentByID(int departmentId);
        void InsertDepartment(Department department);
        void DeleteDepartment(int departmentId);
        void UpdateDepartment(Department department);
    }
}

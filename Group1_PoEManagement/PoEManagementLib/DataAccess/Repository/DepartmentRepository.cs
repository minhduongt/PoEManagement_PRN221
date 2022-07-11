using PoEManagementLib.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoEManagementLib.DataAccess.Repository
{
    public class DepartmentRepository :IDepartmentRepository
    {
        public Department GetDepartmentByID(int departmentId) => DepartmentDAO.Instance.GetDepartmentByID(departmentId);
        public IEnumerable<Department> GetDepartments() => DepartmentDAO.Instance.GetDepartmentList();
        public void InsertDepartment(Department department) => DepartmentDAO.Instance.AddNew(department);
        public void DeleteDepartment(int departmentId) => DepartmentDAO.Instance.Remove(departmentId);
        public void UpdateDepartment(Department department) => DepartmentDAO.Instance.Update(department);
    }
}

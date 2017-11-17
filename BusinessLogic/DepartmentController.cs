using System.Collections.Generic;
using Core;
using DatabaseAccess.Departments;

namespace BusinessLogic
{
    public class DepartmentController
    {
        IDepartmentRepository departmentRepository = new DepartmentRepository();

        public List<Department> GetAllDepartments()
        {
            return departmentRepository.GetAllDepartments();
        }

        public Department GetDepartmentById(int id)
        {
            return departmentRepository.GetDepartmentById(id);
        }
    }
}

using System.Collections.Generic;
using BusinessLogic;
using Core;
using DatabaseAccess.Departments;

namespace ServiceLibrary.Department
{
    public class DepartmentService : IDepartmentService
    {
         IDepartmentController departmentController = new DepartmentController(new DepartmentRepository());

        public List<Core.Department> GetAllDepartments()
        {
            return departmentController.GetAllDepartments();
        }

        public Core.Department GetDepartmentById(int departmentId)
        {
            return departmentController.GetDepartmentById(departmentId);
        }
    }
}

using System.Collections.Generic;
using BusinessLogic;
using DatabaseAccess.Departments;
using Core;

namespace ServiceLibrary.Departments
{
    public class DepartmentService : IDepartmentService
    {
         IDepartmentController departmentController = new DepartmentController(new DepartmentRepository());

        public List<Department> GetAllDepartments()
        {
            return departmentController.GetAllDepartments();
        }

        public Department GetDepartmentById(int departmentId)
        {
            return departmentController.GetDepartmentById(departmentId);
        }

        public List<Department> GetAllDepartmentsByWorkplaceId(int workplaceId)
        {
            return departmentController.GetDepartmentsByWorkplaceId(workplaceId);
        }
    }
}

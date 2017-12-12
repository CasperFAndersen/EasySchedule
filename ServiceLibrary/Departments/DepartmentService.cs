using System.Collections.Generic;
using BusinessLogic;
using DatabaseAccess.Departments;
using Core;

namespace ServiceLibrary.Departments
{

    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentController _departmentController = new DepartmentController();

        public List<Department> GetAllDepartments()
        {
            return _departmentController.GetAllDepartments();
        }

        public Department GetDepartmentById(int departmentId)
        {
            return _departmentController.GetDepartmentById(departmentId);
        }

        public List<Department> GetAllDepartmentsByWorkplaceId(int workplaceId)
        {
            return _departmentController.GetDepartmentsByWorkplaceId(workplaceId);
        }
    }
}

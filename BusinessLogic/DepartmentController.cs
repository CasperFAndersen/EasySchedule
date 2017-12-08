using System.Collections.Generic;
using Core;
using DatabaseAccess.Departments;

namespace BusinessLogic
{
    public class DepartmentController : IDepartmentController
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            this._departmentRepository = departmentRepository;
        }

        public List<Department> GetAllDepartments()
        {
            return _departmentRepository.GetAllDepartments();
        }

        public Department GetDepartmentById(int id)
        {
            return _departmentRepository.GetDepartmentById(id);
        }

        public List<Department> GetDepartmentsByWorkplaceId(int workplaceId)
        {
            return _departmentRepository.GetDepartmentsByWorkplaceId(workplaceId);
        }
    }
}

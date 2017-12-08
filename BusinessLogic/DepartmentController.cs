using System.Collections.Generic;
using Core;
using DatabaseAccess.Departments;
using DatabaseAccess.Employees;

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
            List<Department> departments = _departmentRepository.GetAllDepartments();
            foreach (Department department in departments)
            {
                department.Employees = new EmployeeController(new EmployeeRepository()).GetEmployeesByDepartmentId(department.Id);
            }
            return departments;
        }

        public Department GetDepartmentById(int id)
        {
            Department department = _departmentRepository.GetDepartmentById(id);
            department.Employees = new EmployeeController(new EmployeeRepository()).GetEmployeesByDepartmentId(department.Id);
            return department;
        }

        public List<Department> GetDepartmentsByWorkplaceId(int workplaceId)
        {
            List<Department> departments = _departmentRepository.GetDepartmentsByWorkplaceId(workplaceId);
            foreach (Department department in departments)
            {
                department.Employees = new EmployeeController(new EmployeeRepository()).GetEmployeesByDepartmentId(department.Id);
            }
            return departments;
        }
    }
}

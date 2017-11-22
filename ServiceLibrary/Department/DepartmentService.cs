using System.Collections.Generic;
using BusinessLogic;
using Core;
using DatabaseAccess.Departments;

namespace ServiceLibrary.Department
{
    public class DepartmentService : IDepartmentService
    {
         DepartmentController deptCtrl = new DepartmentController(new DepartmentRepository());
        public List<Core.Department> GetAllDepartments()
        {
            return deptCtrl.GetAllDepartments();
        }

        public Core.Department GetDepartmentById(int depId)
        {
            return deptCtrl.GetDepartmentById(depId);
        }
    }
}

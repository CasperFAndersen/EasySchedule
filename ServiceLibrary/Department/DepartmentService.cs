using System.Collections.Generic;
using BusinessLogic;
using Core;

namespace ServiceLibrary.Department
{
    public class DepartmentService : IDepartmentService
    {
         DepartmentController deptCtrl = new DepartmentController();
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

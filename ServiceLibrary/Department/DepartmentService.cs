using System.Collections.Generic;
using BusinessLogic;

namespace ServiceLibrary.Department
{
    public class DepartmentService : IDepartmentService
    {
         DepartmentController deptCtrl = new DepartmentController();
        public List<Core.Department> GetAllDepartments()
        {
            return deptCtrl.GetAllDepartments();
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using BusinessLogic;

namespace ServiceLibrary
{
    public class DepartmentService : IDepartmentService
    {
         DepartmentController deptCtrl = new DepartmentController();
        public List<Department> GetAllDepartments()
        {
            return deptCtrl.GetAllDepartments();
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using DesktopClient.Services;

namespace DesktopClient
{
    public class DepartmentController
    {
        public async Task<List<Department>> GetDepartmentsByLoggedinEmployee()
        {
            DepartmentProxy departmentProxy = new DepartmentProxy();
            Department department = departmentProxy.GetDepartmentById(MainWindow.Employee.DepartmentId);
            return await departmentProxy.GetAllDepartmentsByWorkplaceIdAsync(department.WorkplaceId);
    
        }

    }
}

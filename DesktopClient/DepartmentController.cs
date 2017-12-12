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
        DepartmentProxy departmentProxy = new DepartmentProxy();
        public async Task<List<Department>> GetDepartmentsByLoggedinEmployee()
        {
            Department department = departmentProxy.GetDepartmentById(MainWindow.Employee.DepartmentId);
            return await departmentProxy.GetAllDepartmentsByWorkplaceIdAsync(department.WorkplaceId);   
        }

        public async Task<Department> GetDepartmentByIdAsync(int departmentId)
        {
            return await departmentProxy.GetDepartmentByIdAsync(departmentId);
        }

    }
}

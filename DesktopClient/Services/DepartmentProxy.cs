using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using DesktopClient.DepartmentService;

namespace DesktopClient.Services
{
    public class DepartmentProxy : IDepartmentService
    {
        DepartmentServiceClient proxy = new DepartmentServiceClient();

        public Department GetDepartmentById(int depId)
        {
            return proxy.GetDepartmentById(depId);
        }

        public Task<Department> GetDepartmentByIdAsync(int depId)
        {
            return proxy.GetDepartmentByIdAsync(depId);
        }

        public List<Department> GetAllDepartments()
        {
            return proxy.GetAllDepartments();
        }

        public Task<List<Department>> GetAllDepartmentsAsync()
        {
            return proxy.GetAllDepartmentsAsync();
        }

        public List<Department> GetAllDepartmentsByWorkplaceId(int workplaceId)
        {
            return proxy.GetAllDepartmentsByWorkplaceId(workplaceId);
        }

        public Task<List<Department>> GetAllDepartmentsByWorkplaceIdAsync(int workplaceId)
        {
            return proxy.GetAllDepartmentsByWorkplaceIdAsync(workplaceId);
        }
    }
}

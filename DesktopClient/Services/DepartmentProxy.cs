using System.Collections.Generic;
using System.Threading.Tasks;
using Core;
using DesktopClient.DepartmentService;

namespace DesktopClient.Services
{
    public class DepartmentProxy : IDepartmentService
    {
        private readonly DepartmentServiceClient _departmentServiceClient = new DepartmentServiceClient();

        public Department GetDepartmentById(int departmentId)
        {
            return _departmentServiceClient.GetDepartmentById(departmentId);
        }

        public Task<Department> GetDepartmentByIdAsync(int departmentId)
        {
            return _departmentServiceClient.GetDepartmentByIdAsync(departmentId);
        }

        public List<Department> GetAllDepartments()
        {
            return _departmentServiceClient.GetAllDepartments();
        }

        public Task<List<Department>> GetAllDepartmentsAsync()
        {
            return _departmentServiceClient.GetAllDepartmentsAsync();
        }

        public List<Department> GetAllDepartmentsByWorkplaceId(int workplaceId)
        {
            return _departmentServiceClient.GetAllDepartmentsByWorkplaceId(workplaceId);
        }

        public Task<List<Department>> GetAllDepartmentsByWorkplaceIdAsync(int workplaceId)
        {
            return _departmentServiceClient.GetAllDepartmentsByWorkplaceIdAsync(workplaceId);
        }
    }
}

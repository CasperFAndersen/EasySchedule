using EasyScheduleWebClient.DepartmentService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core;
using System.Threading.Tasks;

namespace EasyScheduleWebClient.Services
{
    public class DepartmentProxy : IDepartmentService
    {
        DepartmentServiceClient proxy = new DepartmentServiceClient();

        public Department[] GetAllDepartments()
        {
            throw new NotImplementedException();
        }

        public Task<Department[]> GetAllDepartmentsAsync()
        {
            throw new NotImplementedException();
        }

        public Department[] GetAllDepartmentsByWorkplaceId(int workplaceId)
        {
            throw new NotImplementedException();
        }

        public Task<Department[]> GetAllDepartmentsByWorkplaceIdAsync(int workplaceId)
        {
            throw new NotImplementedException();
        }

        public Department GetDepartmentById(int departmentId)
        {
            return proxy.GetDepartmentById(departmentId);
        }

        public Task<Department> GetDepartmentByIdAsync(int departmentId)
        {
            throw new NotImplementedException();
        }
    }
}
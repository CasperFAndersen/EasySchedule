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
        readonly IDepartmentService _departmentServiceClient = new DepartmentServiceClient();


        public List<Department> GetAllDepartments()
        {
            throw new NotImplementedException();
        }

        public Task<List<Department>> GetAllDepartmentsAsync()
        {
            throw new NotImplementedException();
        }

        public Department GetDepartmentById(int departmentId)
        {
            return _departmentServiceClient.GetDepartmentById(departmentId);
        }

        public Task<Department> GetDepartmentByIdAsync(int departmentId)
        {
            throw new NotImplementedException();
        }

        public List<Department> GetAllDepartmentsByWorkplaceId(int workplaceId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Department>> GetAllDepartmentsByWorkplaceIdAsync(int workplaceId)
        {
            throw new NotImplementedException();
        }
    }
}
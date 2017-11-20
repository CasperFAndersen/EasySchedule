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

        public Department[] GetAllDepartments()
        {
            return proxy.GetAllDepartments();
        }

        public Task<Department[]> GetAllDepartmentsAsync()
        {
            throw new NotImplementedException();
        }

    }
}

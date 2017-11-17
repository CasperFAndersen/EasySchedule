using ServiceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using DesktopClient.DepartmentService;

namespace DesktopClient.Services
{
    public class DepartmentProxy : DepartmentService.IDepartmentService
    {
        public Department[] GetAllDepartments()
        {
            throw new NotImplementedException();
        }

        public Task<Department[]> GetAllDepartmentsAsync()
        {
            throw new NotImplementedException();
        }
    }
}

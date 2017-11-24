using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using DesktopClient.Services;

namespace DesktopClient
{
    internal class DepartmentEvents
    {
        public List<Department> LoadDeparmentList()
        {
            List<Department> departments = new List<Department>();
            DepartmentProxy deptProxy = new DepartmentProxy();
            departments = deptProxy.GetAllDepartments().ToList();
            return departments;
        }

    }
}

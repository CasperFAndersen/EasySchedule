using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace DatabaseAccess.Departments
{
    public class MockDepartmentRepository : IDepartmentRepository
    {
        public List<Department> GetAllDepartments()
        {
            List<Department> departments = new List<Department>();
            departments.Add(new Department()
            {
                Address = "Addrese 1, 9999 By",
                Email = "department1@department.dk",
                Id = 1,
                Name = "Department1"
            });
            departments.Add(new Department()
            {
                Address = "Addrese 2, 9999 By",
                Email = "department2@department.dk",
                Id = 2,
                Name = "Department2"
            });
            departments.Add(new Department()
            {
                Address = "Addrese 3, 9999 By",
                Email = "department3@department.dk",
                Id = 3,
                Name = "Department3"
            });
            departments.Add(new Department()
            {
                Address = "Addrese 4, 9999 By",
                Email = "department4@department.dk",
                Id = 4,
                Name = "Department4"
            });
            return departments;
        }

        public Department GetDepartmentById(int id)
        {
            if (id == 1)
            {
                return new Department(){Address = "Department", Email = "address", Id = 1, Name = "Department", Phone = "98765432", WorkplaceId = 1};
            }
            return null;
        }

        public Department BuildDepartmentObject(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}

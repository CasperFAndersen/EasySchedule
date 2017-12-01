using System.Collections.Generic;
using System.Data.SqlClient;
using Core;

namespace DatabaseAccess.Departments
{
    public interface IDepartmentRepository
    {
        List<Department> GetAllDepartments();
        Department GetDepartmentById(int id);
    }
}
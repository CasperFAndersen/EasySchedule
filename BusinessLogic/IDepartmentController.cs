using System.Collections.Generic;
using Core;

namespace BusinessLogic
{
    public interface IDepartmentController
    {
        List<Department> GetAllDepartments();
        Department GetDepartmentById(int id);
        List<Department> GetDepartmentsByWorkplaceId(int workplaceId);
    }
}
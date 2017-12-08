using System.Collections.Generic;
using System.ServiceModel;
using Core;

namespace ServiceLibrary.Departments
{
    [ServiceContract]
    public interface IDepartmentService
    {
        [OperationContract]
        List<Department> GetAllDepartments();

        [OperationContract]
        Department GetDepartmentById(int departmentId);

        [OperationContract]
        List<Department> GetAllDepartmentsByWorkplaceId(int workplaceId);
    }
}

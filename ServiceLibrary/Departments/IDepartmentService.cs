using System.Collections.Generic;
using System.ServiceModel;

namespace ServiceLibrary.Departments
{   [ServiceContract]
    public interface IDepartmentService
    {
        [OperationContract]
        List<Core.Department> GetAllDepartments();

        [OperationContract]
        Core.Department GetDepartmentById(int departmentId);
    }
}

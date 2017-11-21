using System.Collections.Generic;
using System.ServiceModel;

namespace ServiceLibrary.Employee
{
    [ServiceContract]
    public interface IEmployeeService
    {
        [OperationContract]
        Core.Employee GetEmployeeByUsername(string username);
        [OperationContract]
        List<Core.Employee> GetListOfEmployeesByDepartmentID(int departmentID);
        [OperationContract]
        List<Core.Employee> GetListOfEmployeeByDepartmentId(int depId);
    }

}

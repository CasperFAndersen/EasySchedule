using System.Collections.Generic;
using System.ServiceModel;
using Core;

namespace ServiceLibrary.Employee
{
    [ServiceContract]
    public interface IEmployeeService
    {
        [OperationContract]
        Core.Employee GetEmployeeByUsername(string username);
        List<Core.Employee> GetListOfEmployeesByDepartmentId(int departmentId);
        [OperationContract]
        List<Core.Employee> GetListOfEmployeeByDepartmentId(int depId);
        [OperationContract]
        List<Core.Employee> GetAllEmployees();
        [OperationContract]
        void InsertEmployee(Core.Employee employee);
        [OperationContract]
        void UpdateEmployee(Core.Employee employee);

    }

}

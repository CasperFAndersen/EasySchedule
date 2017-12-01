using System.Collections.Generic;
using System.ServiceModel;
using Core;

namespace ServiceLibrary.Employees
{
    [ServiceContract]
    public interface IEmployeeService
    {
        [OperationContract]
        Employee GetEmployeeByUsername(string username);

        [OperationContract]
        List<Employee> GetEmployeesByDepartmentId(int departmentId);

        [OperationContract]
        List<Employee> GetAllEmployees();

        [OperationContract]
        void InsertEmployee(Employee employee);

        [OperationContract]
        void UpdateEmployee(Employee employee);

    }

}

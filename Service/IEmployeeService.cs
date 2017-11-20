using System.ServiceModel;
using Core;
using System.Collections.Generic;

namespace ServiceLibrary
{
    [ServiceContract]
    public interface IEmployeeService
    {
        [OperationContract]
        Employee GetEmployeeByUsername(string username);
        List<Employee> GetListOfEmployeesByDepartmentID(int departmentID);
    }

}

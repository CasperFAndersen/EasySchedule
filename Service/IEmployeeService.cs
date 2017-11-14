using System.ServiceModel;
using Core;

namespace ServiceLibrary
{
    [ServiceContract]
    public interface IEmployeeService
    {
        [OperationContract]
        Employee GetEmployeeByUsername(string username);

        Employee GetEmployeeByUsername3(string username);


    }

}

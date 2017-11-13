using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Core;

namespace Service
{
    [ServiceContract]
    public interface IEmployeeService
    {
        [OperationContract]
        Employee GetEmployeeByUsername(string username);

        Employee GetEmployeeByUsername3(string username);


    }

}

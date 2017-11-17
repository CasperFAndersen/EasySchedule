using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLibrary
{   [ServiceContract]
    public interface IDepartmentService
    {   
        [OperationContract]
        List<Department> GetAllDepartments();
    }
}

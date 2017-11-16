using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleTest;
using Tests.EmployeeService;


namespace Tests.Services
{
    
    [TestClass]
    public class TestService
    {
        
        
        [TestMethod]
        public void EmployeeServiceTest()
        {
            EmployeeServiceClient client = new EmployeeServiceClient();

            //  EmployeeServiceClient client = new EmployeeServiceClient();

            string expected = "Tobias";
            string actual = client.GetEmployeeByUsername("TobMaster").Name;

            Assert.AreEqual(expected, actual);
            //
        }
    }
}

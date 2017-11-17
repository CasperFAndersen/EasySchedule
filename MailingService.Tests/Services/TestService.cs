using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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

            string expected = "Tobias Andersen";
            string actual = client.GetEmployeeByUsername("TobiAs").Name;

            Assert.AreEqual(expected, actual);
            //
        }
    }
}

using System;
using MailingService.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleTest;



namespace Tests.Services
{
    
    [TestClass]
    public class TestService
    {
        
        
        [TestMethod]
        public void EmployeeServiceTest()
        {


            Service empProxy = new Service();

            Assert.AreEqual("Tobias", empProxy.GetEmployeeByUsername("TobMaster"));
        }
    }
}

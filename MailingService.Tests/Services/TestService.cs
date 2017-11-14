using System;
using MailingService.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MailingService.Tests.Services
{
    [TestClass]
    public class TestService
    {
        [TestMethod]
        public void EmployeeServiceTest()
        {
            EmployeeProxy empProxy = new EmployeeProxy();

            Assert.AreEqual("Tobias", empProxy.GetEmployeeByUsername("TobMaster"));
        }
    }
}

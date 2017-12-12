using BusinessLogic.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessLogic.Tests
{
    [TestClass()]
    public class MailSenderTests
    {
        [TestMethod()]
        public void SendMailToEmployeesInDepartmentByDepartmentIdTest()
        {
            string subject = "Test";
            string text = "Test";
            MailSender mailSender = new MailSender();
            //TODO: This have been commented out, so that every time we run the tests, we won't recieve a email.
            //mailSender.SendMailToEmployeesInDepartmentByDepartmentId(subject, text, 1);
            //mailSender.SendMailToEmployeesInDepartmentByDepartmentId(subject, text, 2);
        }
    }
}
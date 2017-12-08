using BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.BusinessLogic
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
            mailSender.SendMailToEmployeesInDepartmentByDepartmentId(subject, text, 1);
            mailSender.SendMailToEmployeesInDepartmentByDepartmentId(subject, text, 2);
        }
    }
}
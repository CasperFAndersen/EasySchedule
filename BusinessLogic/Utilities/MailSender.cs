using System;
using BusinessLogic;
using Core;
using DatabaseAccess.Employees;
using RestSharp;
using RestSharp.Authenticators;

namespace BusinessLogic.Utilities
{
    /// <summary>
    /// This class controls the outgoing emails from the system. 
    /// It uses an api from MailGun.
    /// </summary>
    public class MailSender
    {
        public IRestResponse SendMailToEmployeesInDepartmentByDepartmentId(string subject, string message, int departmentId)
        {
            EmployeeController employeeController = new EmployeeController();
            RestClient client = new RestClient();
            client.BaseUrl = new Uri("https://api.mailgun.net/v3");
            client.Authenticator =
                new HttpBasicAuthenticator("api",
                    "key-0973b4497a2a12bd51960502b8c04573");
            RestRequest request = new RestRequest();
            request.AddParameter("domain", "mailgun.itkrabbe.dk", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "EasySchedule <mailgun@itkrabbe.dk>");
            foreach (Employee employee in employeeController.GetEmployeesByDepartmentId(departmentId))
            {
                request.AddParameter("to", employee.Email);
            }
            request.AddParameter("subject", subject);
            request.AddParameter("text", message);
            request.Method = Method.POST;
            return client.Execute(request);
        }
    }
}

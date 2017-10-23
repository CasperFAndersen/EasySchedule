using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using DatabaseAccess;

namespace BusinessLogic
{
    public class Mail
    {
        EmployeeDB employeeDB = new EmployeeDB();

        public IRestResponse SendSimpleMessage()
        {
            RestClient client = new RestClient();
            client.BaseUrl = new Uri("https://api.mailgun.net/v3");
            client.Authenticator =
                new HttpBasicAuthenticator("api",
                    "key-0973b4497a2a12bd51960502b8c04573");
            RestRequest request = new RestRequest();
            request.AddParameter("domain", "mailgun.itkrabbe.dk", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "Excited User <mailgun@itkrabbe.dk>");
            request.AddParameter("to", "rivercola9800@gmail.com");
            request.AddParameter("to", "stefankrabbe54@gmail.com");
            request.AddParameter("to", "mikkellpaulsen@gmail.com");
            request.AddParameter("to", "arne_ralston@hotmail.com");
            request.AddParameter("subject", "Hello");
            request.AddParameter("text", "Testing some Mailgun awesomness!");
            request.Method = Method.POST;
            return client.Execute(request);
        }

        //TODO: Test når databasen + indhold er lavet. 
        public IRestResponse SendMessageDependingOnEmployeeType(string subject, string text, string type)
        {
            RestClient client = new RestClient();
            client.BaseUrl = new Uri("https://api.mailgun.net/v3");
            client.Authenticator =
                new HttpBasicAuthenticator("api",
                    "key-0973b4497a2a12bd51960502b8c04573");
            RestRequest request = new RestRequest();
            request.AddParameter("domain", "mailgun.itkrabbe.dk", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "Excited User <mailgun@itkrabbe.dk>");

            foreach (var person in employeeDB.GetEmployeeByType(type))
            {
                request.AddParameter("to", person.Mail);
            }
            request.AddParameter("subject", subject);
            request.AddParameter("text", text);
            request.Method = Method.POST;
            return client.Execute(request);
        }

        public IRestResponse SendMessageToAllEmployees(string subject, string text)
        {
            RestClient client = new RestClient();
            client.BaseUrl = new Uri("https://api.mailgun.net/v3");
            client.Authenticator =
                new HttpBasicAuthenticator("api",
                    "key-0973b4497a2a12bd51960502b8c04573");
            RestRequest request = new RestRequest();
            request.AddParameter("domain", "mailgun.itkrabbe.dk", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "Excited User <mailgun@itkrabbe.dk>");

            foreach (var person in employeeDB.GetAll())
            {
                request.AddParameter("to", person.Mail);
            }
            request.AddParameter("subject", subject);
            request.AddParameter("text", text);
            request.Method = Method.POST;
            return client.Execute(request);
        }
    }
}

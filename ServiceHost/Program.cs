using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServiceHosting
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Console Based WCF Host");
            using (ServiceHost serviceHost = new ServiceHost(typeof(TempScheduleService)))

            {
                //open the host and start listening for incoming messages                 
                serviceHost.Open();
                //keep the service running until the Enter key is pressed                 
                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press the Enter key to terminate service.");
                Console.ReadLine();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ServiceLibrary;

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
                DisplayHostInfo(serviceHost);
                //keep the service running until the Enter key is pressed                 
                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press the Enter key to terminate service.");
                Console.WriteLine(serviceHost.BaseAddresses.ToString());
                Console.ReadLine();
            }

        }
        static void DisplayHostInfo(ServiceHost host)
        {
            Console.WriteLine();
            Console.WriteLine("****** Host Info *******");
            foreach (System.ServiceModel.Description.ServiceEndpoint se in host.Description.Endpoints)
            {
                Console.WriteLine("Address: {0}", se.Address);
                Console.WriteLine("Binding: {0}", se.Binding.Name);
                Console.WriteLine("Contract: {0}", se.Contract.Name);
                Console.WriteLine();
            }
            Console.WriteLine("************************");

        }
    }

}

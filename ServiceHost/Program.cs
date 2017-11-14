using System;
using System.ServiceModel;

namespace ServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("WCF EmployeeService is now running.");

            using (ServiceHost host = new ServiceHost(typeof(EmployeeService))) ;
            {
                host.Open();
                Console.WriteLine("Service is now running");
                Console.ReadLine();
            }
        }
    }
}

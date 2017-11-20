
using ServiceLibrary;
using System;
using System.ServiceModel;


namespace ServiceHosting
{
    class Program
    {
        private static ServiceHost ScheHost = new ServiceHost(typeof(ScheduleService));

        private static ServiceHost EmpHost = new ServiceHost(typeof(EmployeeService));

        private static ServiceHost TempScheduleHost = new ServiceHost(typeof(TempScheduleService));


        static void Main(string[] args)
        {
            Console.WriteLine("WCF Services are now running.");

            EmployeeHost();

            TemplateShiftHost();
            ScheduleHost();

            TemplateScheduleHost();

            Console.ReadLine();

            CloseAllHosts();
        }

        private static void CloseAllHosts()
        {
            ScheHost.Close();
            EmpHost.Close();
            TempScheduleHost.Close();
        }

        private static void ScheduleHost()
        {
            
            ScheHost.Open();
            Console.WriteLine("Schedule Service is now running");
        }

        static void EmployeeHost()
        {

            EmpHost.Open();
            Console.WriteLine("Employee Service is now running");

        }

        static void TemplateScheduleHost()
        {
            //open the host and start listening for incoming messages                 
            TempScheduleHost.Open();
            Console.WriteLine("TemplateScheduleService is now running");
            // Kan laves for Services
            //DisplayHostInfo(TempScheduleHost);
            ////keep the service running until the Enter key is pressed                 
            //Console.WriteLine("The service is ready.");
            //Console.WriteLine("Press the Enter key to terminate service.");
            //Console.WriteLine(TempScheduleHost.BaseAddresses.ToString());


        }
        static void TemplateShiftHost()
        {
            Console.WriteLine("TemplateShiftHost Console Based WCF Host");
            using (ServiceHost serviceHost = new ServiceHost(typeof(TempShiftService)))

            {
                //open the host and start listening for incoming messages                 
                serviceHost.Open();
                DisplayHostInfo(serviceHost);
                //keep the service running until the Enter key is pressed                 
                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press the Enter key to terminate service.");
                Console.WriteLine(serviceHost.BaseAddresses.ToString());
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


using ServiceLibrary;
using System;
using System.ServiceModel;


namespace ServiceHosting
{
    class Program
    {
        static ServiceHost tempShiftService = new ServiceHost(typeof(TempShiftService));
        static ServiceHost employeeHost = new ServiceHost(typeof(EmployeeService));
        static ServiceHost scheduleHost = new ServiceHost(typeof(ScheduleService));
        static ServiceHost tempScheduleHost = new ServiceHost(typeof(TempScheduleService));
        static ServiceHost departmentHost = new ServiceHost(typeof(DepartmentService));


        static void Main(string[] args)
        {
            EmployeeHost();
            ScheduleHost();
            TemplateScheduleHost();
            TemplateShiftHost();
            DepartmentHost();

            Console.WriteLine("WCF Services is now running.");

            Console.ReadLine();
            CloseConnections();
        }

        static void CloseConnections()
        {
            tempShiftService.Close();
            employeeHost.Close();
            scheduleHost.Close();
            tempScheduleHost.Close();
            departmentHost.Close();
        }

        static void EmployeeHost()
        {
            employeeHost.Open();
            Console.WriteLine("Employee Service is now running");
        }

        static void ScheduleHost()
        {
            scheduleHost.Open();
            Console.WriteLine("Schedule Service is now running");
        }

        static void TemplateScheduleHost()
        {
            Console.WriteLine("TemplateScheduleHost Console Based WCF Host");

            //open the host and start listening for incoming messages                 
            tempScheduleHost.Open();
            DisplayHostInfo(tempScheduleHost);
            //keep the service running until the Enter key is pressed                 
            Console.WriteLine("The service is ready.");
            Console.WriteLine("Press the Enter key to terminate service.");
            Console.WriteLine(tempScheduleHost.BaseAddresses.ToString());


        }
        static void TemplateShiftHost()
        {
            Console.WriteLine("TemplateShiftHost Console Based WCF Host");
            //open the host and start listening for incoming messages                 
            tempShiftService.Open();
            DisplayHostInfo(tempShiftService);
            //keep the service running until the Enter key is pressed                 
            Console.WriteLine("The service is ready.");
            Console.WriteLine("Press the Enter key to terminate service.");
            Console.WriteLine(tempShiftService.BaseAddresses.ToString());

        }
        static void DepartmentHost()
        {
            Console.WriteLine("TemplateShiftHost Console Based WCF Host");
            //open the host and start listening for incoming messages                 
            departmentHost.Open();
            DisplayHostInfo(departmentHost);
            //keep the service running until the Enter key is pressed                 
            Console.WriteLine("The service is ready.");
            Console.WriteLine("Press the Enter key to terminate service.");
            Console.WriteLine(departmentHost.BaseAddresses.ToString());

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

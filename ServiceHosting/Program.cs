using ServiceLibrary;
using System;
using System.ServiceModel;
using ServiceLibrary.Department;
using ServiceLibrary.Employee;
using ServiceLibrary.Schedule;
using ServiceLibrary.TemplateSchedule;
using ServiceLibrary.TemplateShift;

namespace ServiceHosting
{
    class Program
    {
        static ServiceHost employeeHost = new ServiceHost(typeof(EmployeeService));
        static ServiceHost scheduleHost = new ServiceHost(typeof(ScheduleService));
        static ServiceHost tempScheduleHost = new ServiceHost(typeof(TemplateScheduleService));
        static ServiceHost tempShiftHost = new ServiceHost(typeof(TemplateShiftService));
        static ServiceHost departmentHost = new ServiceHost(typeof(DepartmentService));

        static void Main(string[] args)
        {
            EmployeeHost();
            ScheduleHost();
            TemplateScheduleHost();
            TemplateShiftHost();
            DepartmentHost();

            Console.WriteLine("WCF Services is now running.");

            Console.WriteLine("Press the Enter key to terminate services.");

            Console.ReadLine();
            CloseConnections();
        }

        static void CloseConnections()
        {
            tempShiftHost.Close();
            employeeHost.Close();
            scheduleHost.Close();
            tempScheduleHost.Close();
            departmentHost.Close();
        }

        static void EmployeeHost()
        {
            employeeHost.Open();
            DisplayHostInfo(employeeHost);
            Console.WriteLine("Employee Service is now running");
        }

        static void ScheduleHost()
        {
            scheduleHost.Open();
            DisplayHostInfo(scheduleHost);
            Console.WriteLine("Schedule Service is now running");
        }

        static void TemplateScheduleHost()
        {
            Console.WriteLine("TemplateScheduleHost Console Based WCF Host");
            tempScheduleHost.Open();
            DisplayHostInfo(tempScheduleHost);
        }

        static void TemplateShiftHost()
        {
            Console.WriteLine("TemplateShiftHost Console Based WCF Host");
            tempShiftHost.Open();
            DisplayHostInfo(tempShiftHost);

        }
        static void DepartmentHost()
        {
            Console.WriteLine("TemplateShiftHost Console Based WCF Host");
            departmentHost.Open();
            DisplayHostInfo(departmentHost);

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

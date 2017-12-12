using ServiceLibrary;
using System;
using System.ServiceModel;
using ServiceLibrary.Departments;
using ServiceLibrary.Employees;
using ServiceLibrary.Schedules;
using ServiceLibrary.TemplateSchedules;
using ServiceLibrary.TemplateShifts;
using ServiceLibrary.ScheduleShifts;

namespace ServiceHosting
{
    /// <summary>
    /// This is the class which is responsible for hosting our services. This class starts all the relevant services, which we currently use.
    /// </summary>
    class Program
    {
        static ServiceHost employeeHost = new ServiceHost(typeof(EmployeeService));
        static ServiceHost scheduleHost = new ServiceHost(typeof(ScheduleService));
        static ServiceHost scheduleShiftHost = new ServiceHost(typeof(ScheduleShiftService));
        static ServiceHost templateScheduleHost = new ServiceHost(typeof(TemplateScheduleService));
        static ServiceHost templateShiftHost = new ServiceHost(typeof(TemplateShiftService));
        static ServiceHost departmentHost = new ServiceHost(typeof(DepartmentService));
 
        static void Main(string[] args)
        {
            EmployeeHost();
            ScheduleHost();
            ScheduleShiftHost();
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
            templateShiftHost.Close();
            employeeHost.Close();
            scheduleHost.Close();
            scheduleShiftHost.Close();
            templateScheduleHost.Close();
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

        static void ScheduleShiftHost()
        {
            scheduleShiftHost.Open();
            DisplayHostInfo(scheduleShiftHost);
            Console.WriteLine("ScheduleShift Service is now running");
        }

        static void TemplateScheduleHost()
        {
            templateScheduleHost.Open();
            DisplayHostInfo(templateScheduleHost);
            Console.WriteLine("Template Schedule Service is now running");
        }

        static void TemplateShiftHost()
        {
            templateShiftHost.Open();
            DisplayHostInfo(templateShiftHost);
            Console.WriteLine("Template Shift Service is now running");

        }
        static void DepartmentHost()
        {
            departmentHost.Open();
            DisplayHostInfo(departmentHost);
            Console.WriteLine("Department Service is now running");
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

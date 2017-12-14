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
        private static readonly ServiceHost _employeeHost = new ServiceHost(typeof(EmployeeService));
        private static readonly ServiceHost _scheduleHost = new ServiceHost(typeof(ScheduleService));
        private static readonly ServiceHost _scheduleShiftHost = new ServiceHost(typeof(ScheduleShiftService));
        private static readonly ServiceHost _templateScheduleHost = new ServiceHost(typeof(TemplateScheduleService));
        private static readonly ServiceHost _templateShiftHost = new ServiceHost(typeof(TemplateShiftService));
        private static readonly ServiceHost _departmentHost = new ServiceHost(typeof(DepartmentService));
 
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
            _templateShiftHost.Close();
            _employeeHost.Close();
            _scheduleHost.Close();
            _scheduleShiftHost.Close();
            _templateScheduleHost.Close();
            _departmentHost.Close();
        }

        static void EmployeeHost()
        {
            _employeeHost.Open();
            DisplayHostInfo(_employeeHost, "Employee");
        }

        static void ScheduleHost()
        {
            _scheduleHost.Open();
            DisplayHostInfo(_scheduleHost, "Schedule");
        }

        static void ScheduleShiftHost()
        {
            _scheduleShiftHost.Open();
            DisplayHostInfo(_scheduleShiftHost, "Schedule shift");
        }

        static void TemplateScheduleHost()
        {
            _templateScheduleHost.Open();
            DisplayHostInfo(_templateScheduleHost, "Template schedule");
        }

        static void TemplateShiftHost()
        {
            _templateShiftHost.Open();
            DisplayHostInfo(_templateShiftHost, "Template shift");

        }
        static void DepartmentHost()
        {
            _departmentHost.Open();
            DisplayHostInfo(_departmentHost, "Department");
        }

        static void DisplayHostInfo(ServiceHost host, string serviceName)
        {
            Console.WriteLine("****** Host Info *******");
            foreach (System.ServiceModel.Description.ServiceEndpoint se in host.Description.Endpoints)
            {
                Console.WriteLine("Address: {0}", se.Address);
                Console.WriteLine("Binding: {0}", se.Binding.Name);
                Console.WriteLine("Contract: {0}", se.Contract.Name);
                Console.WriteLine();
            }
            Console.WriteLine(serviceName + " service is now running");
            Console.WriteLine("**********************************************************");
            Console.WriteLine();
        }
    }
}

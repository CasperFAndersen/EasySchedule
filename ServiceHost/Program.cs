
﻿using Service;

using System;
using System.ServiceModel;


namespace ServiceHosting
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("WCF Services is now running.");

            ServiceHost EmpHost = new ServiceHost(typeof(EmployeeService));
           // ServiceHost ScheHost = new ServiceHost(typeof(ScheduleService));

            EmpHost.Open();
            Console.WriteLine("Employee Service is now running");
      

            //ScheHost.Open();
            //Console.WriteLine("Schedule Service is now running");

            Console.ReadLine();

            EmpHost.Close();
           // ScheHost.Close();


        }
    }
}

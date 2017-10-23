namespace DatabaseAccess
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using Core;

    public class EmployeeDB : DbContext
    {
        // Your context has been configured to use a 'Employee' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'DatabaseAccess.Employee' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Employee' 
        // connection string in the application configuration file.
        public EmployeeDB()
            : base("name=Employee")
        {
        }

        public IEnumerable<Employee> GetEmployeeByType(string type)
        {
            List<Employee> emplooyees = new List<Employee>();
            return emplooyees;
        }

        public IEnumerable<Employee> GetAll()
        {
            List<Employee> emplooyees = new List<Employee>();
            return emplooyees;
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}
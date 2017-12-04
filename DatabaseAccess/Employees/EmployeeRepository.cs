using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Core;
using System.Transactions;

namespace DatabaseAccess.Employees
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();

            using (SqlConnection connection = new DbConnection().GetConnection())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Employee";
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Employee employee = BuildEmployeeObject(reader);
                            employees.Add(employee);
                        }
                    }
                }
            }
            return employees;
        }

        public Employee GetEmployeeByUsername(string username)
        {
            Employee employee = new Employee();
            using (SqlConnection connection = new DbConnection().GetConnection())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Employee WHERE Employee.username = @param1;";
                    SqlParameter p1 = new SqlParameter(@"param1", SqlDbType.NVarChar);
                    p1.Value = username;
                    command.Parameters.Add(p1);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            employee = BuildEmployeeObject(reader);
                        }
                    }
                }
            }
            return employee;
        }

        public Employee FindEmployeeById(int id)
        {
            Employee empRes = new Employee();
            using (SqlConnection connection = new DbConnection().GetConnection())
            {
                //connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Employee WHERE Employee.id = @param1;";
                    SqlParameter p1 = new SqlParameter(@"param1", SqlDbType.Int);
                    p1.Value = id;
                    command.Parameters.Add(p1);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            empRes = BuildEmployeeObject(reader);
                        }
                    }
                }
            }
            return empRes;
        }

        public List<Employee> GetEmployeesByDepartmentId(int departmentId)
        {
            List<Employee> employees = new List<Employee>();
            using (SqlConnection connection = new DbConnection().GetConnection())
            {
                //connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Employee WHERE Employee.DepartmentId = @param1;";
                    SqlParameter p1 = new SqlParameter(@"param1", SqlDbType.Int, 100);
                    p1.Value = departmentId;
                    command.Parameters.Add(p1);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Employee employee = BuildEmployeeObject(reader);
                            employees.Add(employee);
                        }
                    }
                }
            }
            return employees;
        }

        public void InsertEmployee(Employee employee)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    using (SqlConnection connection = new DbConnection().GetConnection())
                    {
                        using (SqlCommand command = connection.CreateCommand())
                        {



                            command.CommandText =
                                "insert into Employee(name, email, phone, noOfHours, isAdmin, username, password, departmentId, isEmployed) " +
                                "values (@param1, @param2, @param3, @param4, @param5, @param6, @param7, @param8, @param9);";

                            SqlParameter p1 = new SqlParameter(@"param1", SqlDbType.VarChar, 100);
                            SqlParameter p2 = new SqlParameter(@"param2", SqlDbType.VarChar, 100);
                            SqlParameter p3 = new SqlParameter(@"param3", SqlDbType.VarChar, 100);
                            SqlParameter p4 = new SqlParameter(@"param4", SqlDbType.Int, 100);
                            SqlParameter p5 = new SqlParameter(@"param5", SqlDbType.Bit, 100);
                            SqlParameter p6 = new SqlParameter(@"param6", SqlDbType.VarChar, 100);
                            SqlParameter p7 = new SqlParameter(@"param7", SqlDbType.VarChar, 100);
                            SqlParameter p8 = new SqlParameter(@"param8", SqlDbType.Int, 100);
                            SqlParameter p9 = new SqlParameter(@"param9", SqlDbType.Bit, 100);

                            p1.Value = employee.Name;
                            p2.Value = employee.Mail;
                            p3.Value = employee.Phone;
                            p4.Value = employee.NumbOfHours;
                            p5.Value = employee.IsAdmin;
                            p6.Value = employee.Username;
                            p7.Value = employee.Password;
                            p8.Value = employee.DepartmentId;
                            p9.Value = employee.IsEmployed;

                            command.Parameters.Add(p1);
                            command.Parameters.Add(p2);
                            command.Parameters.Add(p3);
                            command.Parameters.Add(p4);
                            command.Parameters.Add(p5);
                            command.Parameters.Add(p6);
                            command.Parameters.Add(p7);
                            command.Parameters.Add(p8);
                            command.Parameters.Add(p9);

                            command.ExecuteNonQuery();

                            scope.Complete();
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("Something went wrong! Try again");
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    using (SqlConnection connection = new DbConnection().GetConnection())
                    {
                        using (SqlCommand command = connection.CreateCommand())
                        {
                            command.CommandText =
                                "UPDATE Employee Set name = @param1, email = @param2, phone = @param3, noOfHours = @param4, " +
                                "isAdmin = @param5, username = @param6, password = @param7, departmentId = @param8, isEmployed = @param9 " +
                                "WHERE employee.id = @param10;";

                            SqlParameter p1 = new SqlParameter(@"param1", SqlDbType.VarChar, 100);
                            SqlParameter p2 = new SqlParameter(@"param2", SqlDbType.VarChar, 100);
                            SqlParameter p3 = new SqlParameter(@"param3", SqlDbType.VarChar, 100);
                            SqlParameter p4 = new SqlParameter(@"param4", SqlDbType.Int, 100);
                            SqlParameter p5 = new SqlParameter(@"param5", SqlDbType.Bit, 100);
                            SqlParameter p6 = new SqlParameter(@"param6", SqlDbType.VarChar, 100);
                            SqlParameter p7 = new SqlParameter(@"param7", SqlDbType.VarChar, 100);
                            SqlParameter p8 = new SqlParameter(@"param8", SqlDbType.Int, 100);
                            SqlParameter p9 = new SqlParameter(@"param9", SqlDbType.Bit, 100);
                            SqlParameter p10 = new SqlParameter(@"param10", SqlDbType.Int, 100);

                            p1.Value = employee.Name;
                            p2.Value = employee.Mail;
                            p3.Value = employee.Phone;
                            p4.Value = employee.NumbOfHours;
                            p5.Value = employee.IsAdmin;
                            p6.Value = employee.Username;
                            p7.Value = employee.Password;
                            p8.Value = employee.DepartmentId;
                            p9.Value = employee.IsEmployed;
                            p10.Value = employee.Id;

                            command.Parameters.Add(p1);
                            command.Parameters.Add(p2);
                            command.Parameters.Add(p3);
                            command.Parameters.Add(p4);
                            command.Parameters.Add(p5);
                            command.Parameters.Add(p6);
                            command.Parameters.Add(p7);
                            command.Parameters.Add(p8);
                            command.Parameters.Add(p9);
                            command.Parameters.Add(p10);

                            command.ExecuteNonQuery();

                            scope.Complete();
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("Something went wrong! Try again");
            }
        }


        public string GetSaltFromEmployeePassword(Employee employee)
        {
            //Employee employee = GetEmployeeByUsername(username);
            string salt = "";
            using (SqlConnection connection = new DbConnection().GetConnection())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT Salt FROM Employee WHERE Employee.username = @param1;";
                    SqlParameter p1 = new SqlParameter(@"param1", SqlDbType.NVarChar);
                    p1.Value = employee.Username;
                    command.Parameters.Add(p1);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            salt = reader["Salt"].ToString();
                        }
                    }
                }
            }
            return salt;
        }

        public Employee BuildEmployeeObject(SqlDataReader reader)
        {
            Employee employee = new Employee();
            employee.Id = Convert.ToInt32(reader["Id"].ToString());
            employee.Name = reader["Name"].ToString();
            employee.Mail = reader["Email"].ToString();
            employee.Phone = reader["Phone"].ToString();
            employee.NumbOfHours = Convert.ToInt32(reader["NoOfHours"].ToString());
            employee.IsAdmin = reader.GetBoolean(5);
            employee.Username = reader["username"].ToString();
            employee.Password = reader["password"].ToString();
            employee.DepartmentId = Convert.ToInt32(reader["departmentId"].ToString());
            employee.IsEmployed = reader.GetBoolean(9);
            return employee;
        }
    }
}

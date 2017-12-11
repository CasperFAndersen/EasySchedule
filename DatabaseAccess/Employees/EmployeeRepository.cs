using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using Core;
using System.Transactions;

namespace DatabaseAccess.Employees
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public List<Employee> GetAllEmployees()
        {
            try
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
            catch (Exception)
            {

                throw new Exception("Something went wrong while retriving all employees! Try again");
            }
        }

        public Employee GetEmployeeById(int id)
        {
            Employee employee = new Employee();
            using (SqlConnection connection = new DbConnection().GetConnection())
            {
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
                            employee = BuildEmployeeObject(reader);
                        }
                    }
                }
            }
            return employee;
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

        public string GetSaltFromEmployeePassword(Employee employee)
        {
            string salt = null;
            using (SqlConnection connection = new DbConnection().GetConnection())
            {
                using (SqlCommand commmand = connection.CreateCommand())
                {
                    commmand.CommandText = "SELECT salt FROM Employee where Id = @param1";
                    commmand.Parameters.AddWithValue("@param1", employee.Id);
                    using (SqlDataReader reader = commmand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            salt = reader.GetString(0);
                        }
                    }
                }
            }
            return salt;
        }

        public Employee FindEmployeeById(int id)
        {
            try
            {
                Employee empRes = null;
                using (SqlConnection connection = new DbConnection().GetConnection())
                {
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
            catch (Exception)
            {

                throw new Exception("Something went wrong while looking for that employee! Try again.");
            }
        }

        public List<Employee> GetEmployeesByDepartmentId(int departmentId)
        {
            try
            {
                List<Employee> employees = new List<Employee>();
                using (SqlConnection connection = new DbConnection().GetConnection())
                {
                    //connection.Open();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM Employee WHERE Employee.departmentId = @param1;";
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
            catch (Exception)
            {

                throw new Exception("Something went wrong! Try again.");
            }
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
                                "insert into Employee(name, email, phone, noOfHours, isAdmin, username, password, departmentId, isEmployed, salt) " +
                                "values (@param1, @param2, @param3, @param4, @param5, @param6, @param7, @param8, @param9, @param10);";

                            SqlParameter p1 = new SqlParameter(@"param1", SqlDbType.VarChar, 100);
                            SqlParameter p2 = new SqlParameter(@"param2", SqlDbType.VarChar, 100);
                            SqlParameter p3 = new SqlParameter(@"param3", SqlDbType.VarChar, 100);
                            SqlParameter p4 = new SqlParameter(@"param4", SqlDbType.Int, 100);
                            SqlParameter p5 = new SqlParameter(@"param5", SqlDbType.Bit, 100);
                            SqlParameter p6 = new SqlParameter(@"param6", SqlDbType.VarChar, 100);
                            SqlParameter p7 = new SqlParameter(@"param7", SqlDbType.VarChar, 100);
                            SqlParameter p8 = new SqlParameter(@"param8", SqlDbType.Int, 100);
                            SqlParameter p9 = new SqlParameter(@"param9", SqlDbType.Bit, 100);
                            SqlParameter p10 = new SqlParameter(@"param10", SqlDbType.VarChar, 100);

                            p1.Value = employee.Name;
                            p2.Value = employee.Email;
                            p3.Value = employee.Phone;
                            p4.Value = employee.NoOfHours;
                            p5.Value = employee.IsAdmin;
                            p6.Value = employee.Username;
                            p7.Value = employee.Password;
                            p8.Value = employee.DepartmentId;
                            p9.Value = employee.IsEmployed;
                            p10.Value = employee.Salt;

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
                throw new Exception("Something went wrong while inserting an employee into the database! Try again");
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
                                "isAdmin = @param5, username = @param6, password = @param7, departmentId = @param8, isEmployed = @param9, salt = @param10 " +
                                "WHERE employee.id = @param11";

                            SqlParameter p1 = new SqlParameter(@"param1", SqlDbType.VarChar);
                            SqlParameter p2 = new SqlParameter(@"param2", SqlDbType.VarChar);
                            SqlParameter p3 = new SqlParameter(@"param3", SqlDbType.VarChar);
                            SqlParameter p4 = new SqlParameter(@"param4", SqlDbType.Int);
                            SqlParameter p5 = new SqlParameter(@"param5", SqlDbType.Bit);
                            SqlParameter p6 = new SqlParameter(@"param6", SqlDbType.VarChar);
                            SqlParameter p7 = new SqlParameter(@"param7", SqlDbType.VarChar);
                            SqlParameter p8 = new SqlParameter(@"param8", SqlDbType.Int);
                            SqlParameter p9 = new SqlParameter(@"param9", SqlDbType.Bit);
                            SqlParameter p10 = new SqlParameter(@"param10", SqlDbType.VarChar);
                            SqlParameter p11 = new SqlParameter(@"param11", SqlDbType.Int);

                            p1.Value = employee.Name;
                            p2.Value = employee.Email;
                            p3.Value = employee.Phone;
                            p4.Value = employee.NoOfHours;
                            p5.Value = employee.IsAdmin;
                            p6.Value = employee.Username;
                            p7.Value = employee.Password;
                            p8.Value = employee.DepartmentId;
                            p9.Value = employee.IsEmployed;
                            p10.Value = employee.Salt;
                            p11.Value = employee.Id;

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
                            command.Parameters.Add(p11);

                            command.ExecuteNonQuery();

                            scope.Complete();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Something went wrong while updating an employee! Try again");
                //Debug.Print(e.StackTrace);
            }
        }

        /// <summary>
        /// This method builds a new Employee object with the information retrieved from the database.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>
        /// Returns a employee object.
        /// </returns>
        public Employee BuildEmployeeObject(SqlDataReader reader)
        {
            Employee employee = new Employee();
            employee.Id = Convert.ToInt32(reader["Id"].ToString());
            employee.Name = reader["Name"].ToString();
            employee.Email = reader["Email"].ToString();
            employee.Phone = reader["Phone"].ToString();
            employee.NoOfHours = Convert.ToInt32(reader["NoOfHours"].ToString());
            employee.IsAdmin = reader.GetBoolean(5);
            employee.Username = reader["Username"].ToString();
            employee.Password = reader["Password"].ToString();
            employee.DepartmentId = Convert.ToInt32(reader["DepartmentId"].ToString());
            employee.Salt = reader["Salt"].ToString();
            employee.IsEmployed = reader.GetBoolean(10);
            return employee;
        }
    }
}

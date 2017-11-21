using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Core;

namespace DatabaseAccess.Employees
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();

            using (SqlConnection connection = new DbConnectionADO().GetConnection())
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Employee";
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                    while (reader.Read())
                    {
                        employees.Add(BuildEmployeeObject(reader));
                    }

                    connection.Close();
                }
            }
            return employees;
        }

        public Employee GetEmployeeByUsername(string username)
        {
            Employee empRes = new Employee();

            using (SqlConnection conn = new DbConnectionADO().GetConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {

                    cmd.CommandText = "SELECT * FROM Employee WHERE Employee.username = @param1;";
                    SqlParameter p1 = new SqlParameter(@"param1", System.Data.SqlDbType.NVarChar, 100);
                    p1.Value = username;

                    cmd.Parameters.Add(p1);

                    SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                    while (reader.Read())
                    {
                        empRes = BuildEmployeeObject(reader);
                    }


                    conn.Close();

                    return empRes;
                }

            }
        }


        public Employee FindEmployeeById(int id)
        {
            Employee empRes = new Employee();

            using (SqlConnection conn = new DbConnectionADO().GetConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {

                    cmd.CommandText = "SELECT * FROM Employee WHERE Employee.id = @param1;";
                    SqlParameter p1 = new SqlParameter(@"param1", System.Data.SqlDbType.Int);
                    p1.Value = id;

                    cmd.Parameters.Add(p1);

                    SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                    while (reader.Read())
                    {
                        empRes = BuildEmployeeObject(reader);
                    }


                    conn.Close();

                    return empRes;
                }

            }
        }


        public Employee BuildEmployeeObject(SqlDataReader reader)
        {
            Employee emp = new Employee();

            emp.Id = Convert.ToInt32(reader["Id"].ToString());
            emp.Name = reader["Name"].ToString();
            emp.Mail = reader["Email"].ToString();
            emp.Phone = reader["Phone"].ToString();
            emp.NumbOfHours = Convert.ToInt32(reader["NoOfHours"].ToString());
            emp.IsAdmin = reader.GetBoolean(5);
            emp.Username = reader["username"].ToString();
            emp.Password = reader["password"].ToString();
            emp.DepartmentId = Convert.ToInt32(reader["departmentId"].ToString());

            return emp;

        }

        public List<Employee> GetListOfEmployeesByDepartmentID(int departmentID)
        {
            List<Employee> empList = new List<Employee>();

            using (SqlConnection conn = new DbConnectionADO().GetConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {

                    cmd.CommandText = "SELECT * FROM Employee WHERE Employee.DepartmentId = @param1;";
                    SqlParameter p1 = new SqlParameter(@"param1", System.Data.SqlDbType.Int, 100);
                    p1.Value = departmentID;

                    cmd.Parameters.Add(p1);

                    SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                    while (reader.Read())
                    {
                        Employee e = BuildEmployeeObject(reader);
                        empList.Add(e);
                    }
                    conn.Close();

                    return empList;
                }

            }
        }
    }
}

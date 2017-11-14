using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Core;

namespace DatabaseAccess.Employees
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public List<Employee> GetAllEmployees()
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployeeByUsername(string username)
        {
            Employee empRes = new Employee();

            using (DbConnectionADO dbCon = new DbConnectionADO())
            {
                dbCon.OpenConnection();
                SqlCommand selectEmployeeByUsername = new SqlCommand("SELECT FROM Employee WHERE username = @param1");
                selectEmployeeByUsername.Parameters.AddWithValue("@param1", username);
                
                SqlDataReader reader = selectEmployeeByUsername.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                while (reader.Read())
                {
                    empRes = BuildEmployeeObject(reader);
                }


                dbCon.CloseConnection();

                return empRes;
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
            emp.IsAdmin = reader.GetBoolean(6);
            emp.Username = reader["username"].ToString();
            emp.Password = reader["password"].ToString();

            return emp;

        }
    }
}

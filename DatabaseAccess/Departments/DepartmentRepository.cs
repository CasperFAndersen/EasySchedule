using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using DatabaseAccess.Employees;

namespace DatabaseAccess.Departments
{
    public class DepartmentRepository : IDepartmentRepository
    {
        public List<Department> GetAllDepartments()
        {
            List<Department> departments = new List<Department>();

            using (SqlConnection connection = new DbConnection().GetConnection())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Department";
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Department department = BuildDepartmentObject(reader);
                            departments.Add(department);
                        }
                    }
                }
            }
            return departments;
        }

        public Department GetDepartmentById(int id)
        {
            Department department = new Department();
            using (SqlConnection connection = new DbConnection().GetConnection())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Department WHERE Department.id = @param1;";
                    SqlParameter param1 = new SqlParameter("@param1", SqlDbType.Int);
                    param1.Value = id;
                    command.Parameters.Add(param1);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            department = BuildDepartmentObject(reader);
                        }
                    }
                }
            }
            return department;
        }

        public List<Department> GetDepartmentsByWorkplaceId(int workplaceId)
        {
            List<Department> departments = new List<Department>();

            using (SqlConnection connection = new DbConnection().GetConnection())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Department WHERE Department.workplaceId = @param1";
                    SqlParameter param1 = new SqlParameter("@param1", SqlDbType.Int);
                    param1.Value = workplaceId;
                    command.Parameters.Add(param1);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Department department = BuildDepartmentObject(reader);
                            departments.Add(department);
                        }
                    }
                }
            }
            return departments;
        }

        /// <summary>
        /// This method builds a new department object with the information retrieved from the database.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>
        /// Returns a department object.
        /// </returns>
        public Department BuildDepartmentObject(SqlDataReader reader)
        {
            Department department = new Department();
            department.Id = Convert.ToInt32(reader["id"].ToString());
            department.Name = reader["name"].ToString();
            department.Address = reader["address"].ToString();
            department.Email = reader["email"].ToString();
            department.Phone = reader["phone"].ToString();
            department.WorkplaceId = Convert.ToInt32(reader["workplaceId"].ToString());
            return department;
        }
    }
}

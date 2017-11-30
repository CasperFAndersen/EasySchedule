﻿using System;
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
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Department";
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        departments.Add(BuildDepartmentObject(reader));
                    }

                    connection.Close();

                }
            }
            return departments;
        }

        public Department GetDepartmentById(int id)
        {
            Department department = new Department();

            using (SqlConnection connection = new DbConnection().GetConnection())
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Department WHERE Department.id = @param1;";
                    SqlParameter param1 = new SqlParameter("@param1", SqlDbType.Int);
                    param1.Value = id;

                    cmd.Parameters.Add(param1);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        department = BuildDepartmentObject(reader);
                    }

                    connection.Close();
                }
            }
            return department;
        }

        public Department BuildDepartmentObject(SqlDataReader reader)
        {
            Department department = new Department();
            department.Id = Convert.ToInt32(reader["id"].ToString());
            department.Name = reader["name"].ToString();
            department.Address = reader["address"].ToString();
            department.Email = reader["email"].ToString();
            department.Phone = reader["phone"].ToString();
            department.WorkplaceId = Convert.ToInt32(reader["workplaceId"].ToString());
            department.Employees = new EmployeeRepository().GetListOfEmployeesByDepartmentId(department.Id);
            return department;
        }
    }
}

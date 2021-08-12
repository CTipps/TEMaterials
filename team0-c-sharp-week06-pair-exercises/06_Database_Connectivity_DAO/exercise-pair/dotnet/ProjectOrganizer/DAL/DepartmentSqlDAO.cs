using ProjectOrganizer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ProjectOrganizer.DAL
{
    public class DepartmentSqlDAO : IDepartmentDAO
    {
        private readonly string connectionString;
        private string sqlGetDepartment = "SELECT * FROM department;";
        private string sqlCreateDepartment = "INSERT INTO department (name) VALUES (@name);";
        private string sqlUpdateDepartment = "UPDATE department SET name = @name WHERE department_id = @id;";

        // Single Parameter Constructor
        public DepartmentSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        /// <summary>
        /// Returns a list of all of the departments.
        /// </summary>
        /// <returns></returns>
        public IList<Department> GetDepartments()
        {
            IList<Department> result = new List<Department>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlGetDepartment, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Department department = new Department();
                        department.Id = Convert.ToInt32(reader["department_id"]);
                        department.Name = Convert.ToString(reader["name"]);

                        result.Add(department);
                    }
                }

            }
            catch
            {
                result = new List<Department>();
            }
            return result;

        }

        /// <summary>
        /// Creates a new department.
        /// </summary>
        /// <param name="newDepartment">The department object.</param>
        /// <returns>The id of the new department (if successful).</returns>
        /// 
        public int CreateDepartment(string name)
        {
            Department department = new Department(name);
            return CreateDepartment(department);
        }

        public int CreateDepartment(Department newDepartment)
        {
            int result = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlCreateDepartment, conn);

                    cmd.Parameters.AddWithValue("@name", newDepartment.Name);
                    cmd.ExecuteNonQuery();

   
                    SqlCommand cmd2 = new SqlCommand(sqlGetDepartment, conn);
                    SqlDataReader reader = cmd2.ExecuteReader();

                    while (reader.Read())
                    {
                        Department department = new Department();
                        department.Id = Convert.ToInt32(reader["department_id"]);
                        department.Name = Convert.ToString(reader["name"]);

                        if (department.Name == newDepartment.Name)
                        {
                            result = department.Id;
                        }

                    }

                }


            }
            catch
            {
                result = 0;
            }
            return result;
        }

        /// <summary>
        /// Updates an existing department.
        /// </summary>
        /// <param name="updatedDepartment">The department object.</param>
        /// <returns>True, if successful.</returns>
        /// 
        public bool UpdateDepartment(int id, string name)
        {
            Department updatedDepartment = new Department
            {
                Id = id,
                Name = name
            };
            return UpdateDepartment(updatedDepartment);
        }

        public bool UpdateDepartment(Department updatedDepartment)
        {
            bool result = false;
            int count = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlUpdateDepartment, conn);

                    cmd.Parameters.AddWithValue("@name", updatedDepartment.Name);
                    cmd.Parameters.AddWithValue("@id", updatedDepartment.Id);
                    count = cmd.ExecuteNonQuery();

                    if (count > 0)
                    {
                        result = true;
                    }

                }
            }
            catch
            {

                result = false;
            }

            return result;
        }
            
    }
}

using ProjectOrganizer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ProjectOrganizer.DAL
{
    public class ProjectSqlDAO : IProjectDAO
    {
        private readonly string connectionString;
        private string sqlGetAllProjects = "SELECT * FROM project";
        private string sqlAssignEmployeeToProject = "INSERT INTO project_employee (project_id, employee_id) Values (@project_id, @employee_id);";
        private string sqlDeleteEmployeeFromProject = "DELETE FROM project_employee WHERE project_id = @project_id AND employee_id = @employee_id;";
        private string sqlCreateNewProject = "INSERT INTO project (name, from_date, to_date) VALUES (@name, @start_date, @end_date);";
        
        
        // Single Parameter Constructor
        public ProjectSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        /// <summary>
        /// Returns all projects.
        /// </summary>
        /// <returns></returns>
        public IList<Project> GetAllProjects()
        {
            List<Project> result = new List<Project>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlGetAllProjects, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Project project = new Project();
                        project.ProjectId = Convert.ToInt32(reader["project_id"]);
                        project.Name = Convert.ToString(reader["name"]);
                        project.StartDate = Convert.ToDateTime(reader["from_date"]);
                        project.EndDate = Convert.ToDateTime(reader["to_date"]);

                        result.Add(project);
                    }
                }
            }
            catch
            {
                result = new List<Project>();
            }
            return result;
        }

        /// <summary>
        /// Assigns an employee to a project using their IDs.
        /// </summary>
        /// <param name="projectId">The project's id.</param>
        /// <param name="employeeId">The employee's id.</param>
        /// <returns>If it was successful.</returns>
        public bool AssignEmployeeToProject(int projectId, int employeeId)
        {
            bool result = false;
            int count = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlAssignEmployeeToProject, conn);
                    cmd.Parameters.AddWithValue("@employee_id", employeeId);
                    cmd.Parameters.AddWithValue("@project_id", projectId);

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


        /// <summary>
        /// Removes an employee from a project.
        /// </summary>
        /// <param name="projectId">The project's id.</param>
        /// <param name="employeeId">The employee's id.</param>
        /// <returns>If it was successful.</returns>
        public bool RemoveEmployeeFromProject(int projectId, int employeeId)
        {
            bool result = false;
            int count = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlDeleteEmployeeFromProject, conn);
                    cmd.Parameters.AddWithValue("@employee_id", employeeId);
                    cmd.Parameters.AddWithValue("@project_id", projectId);

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

        /// <summary>
        /// Creates a new project.
        /// </summary>
        /// <param name="newProject">The new project object.</param>
        /// <returns>The new id of the project.</returns>
       
        public int CreateProject(string name, string startDate, string endDate)
        {
            Project project = new Project(name, startDate, endDate);
            return CreateProject(project);
        }


        public int CreateProject(Project newProject)
        {
            int result = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlCreateNewProject, conn);

                    cmd.Parameters.AddWithValue("@name", newProject.Name);
                    cmd.Parameters.AddWithValue("@start_date", newProject.StartDate);
                    cmd.Parameters.AddWithValue("@end_date", newProject.EndDate);
                    cmd.ExecuteNonQuery();


                    SqlCommand cmd2 = new SqlCommand(sqlGetAllProjects, conn);
                    SqlDataReader reader = cmd2.ExecuteReader();

                    while (reader.Read())
                    {
                        Project project = new Project();
                        project.ProjectId = Convert.ToInt32(reader["project_id"]);
                        project.Name = Convert.ToString(reader["name"]);

                        if (project.Name == newProject.Name)
                        {
                            result = project.ProjectId;
                        }

                    }

                }


            }
            catch (Exception ex)
            { 
                result = 0;
            }
            return result;
        }

    }
}

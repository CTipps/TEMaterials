using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectOrganizer.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Transactions;

namespace ProjectOrganizerTest
{
    [TestClass]
    public class TestProjectSqlDAO
    {

        ProjectSqlDAO projectDAO;
        private string connectionString = @"Data Source=.\sqlexpress;Initial Catalog=EmployeeDB;Integrated Security=True";

        private TransactionScope tran;


        [TestInitialize]
        public void Setup()
        {
            tran = new TransactionScope();

            // Arrange
            projectDAO = new ProjectSqlDAO(connectionString);
        }

        [TestCleanup]
        public void Cleanup()
        {
            tran.Dispose();
        }

        [TestMethod]
        [DataRow (1,2)]
        public void TestAssignEmployeeToProject(int projectId, int employeeId)
        {
           bool result = projectDAO.AssignEmployeeToProject(projectId, employeeId);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestRemoveEmployeeFromProject()
        {
            int testProjectId = 0;
            int testEmployeeId = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO project_employee (project_id, employee_id) Values (1, 2);", conn);

                int count = cmd.ExecuteNonQuery();

                Assert.IsTrue(count > 0);

                cmd = new SqlCommand(
                    "SELECT * FROM project_employee WHERE employee_id = 2 AND project_id = 1;", conn);

                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    testProjectId = Convert.ToInt32(reader["project_id"]);
                    testEmployeeId = Convert.ToInt32(reader["employee_id"]);
                }
            }

            bool result = false;

            if (testProjectId > 0)
            {
                result = projectDAO.RemoveEmployeeFromProject(testProjectId, testEmployeeId);
            }

            Assert.IsTrue(result);
        }

        [TestMethod]
        [DataRow("Test Project", "2021/06/14", "2021/06/15")]
        public void TestCreateProject(string name, string startDate, string endDate)
        {
            int result = 0;
            bool testResult = false;
            result = projectDAO.CreateProject(name, startDate, endDate);
            if (result > 0) {
                testResult = true;
            } 
                Assert.IsTrue(testResult);
        }
    }
}

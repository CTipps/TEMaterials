using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectOrganizer;
using ProjectOrganizer.DAL;
using System.Transactions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ProjectOrganizer.Models;

namespace ProjectOrganizerTest
{
    [TestClass]
    public class DAOTest
    {
        DepartmentSqlDAO departmentSqlDAO;
        private string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=EmployeeDB;Integrated Security=True";

        private TransactionScope tran;

        [TestInitialize]
        public void Setup()
        {
            tran = new TransactionScope();
            //Arange
            departmentSqlDAO = new DepartmentSqlDAO(connectionString);
        }

        [TestCleanup]
        public void Cleanup()
        {
            tran.Dispose();
        }

        [TestMethod]

        public void DepartmentDAOConstructor()
        {
            Assert.IsNotNull(departmentSqlDAO);
        }

        [TestMethod]
        public void GetDepartmentsTest()
        {
            //Act
            IList<Department> departments = departmentSqlDAO.GetDepartments();
            //Assert
            Assert.IsNotNull(departments);

        }
        [TestMethod]
        [DataRow("Marketing")]
        [DataRow("Sales")]
        [DataRow("")]
        [DataRow("IT")]
        [DataRow("Ssdfa")]
        public void CreateDepartmentTest(string name)
        {
            //Act
            IList<Department> departments = departmentSqlDAO.GetDepartments();
            int count = departments.Count;
            departmentSqlDAO.CreateDepartment(name);
            departments = departmentSqlDAO.GetDepartments();

            //Assert
            Assert.AreEqual(count + 1, departments.Count);

        }

        [TestMethod]
        [DataRow(1, "Sales")]
        [DataRow(2, "")]
        [DataRow(4, "Finance")]
        [DataRow(3, "IT")]
        [DataRow(4, "Marketing")]
        public void UpdateDepartmentTest(int id, string name)
        {

           //Act
            departmentSqlDAO.UpdateDepartment(id, name);

            string testName = "";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"SELECT name FROM department WHERE department_id = {id};", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                if(reader.Read())
                {
                    testName = Convert.ToString(reader["name"]);
                }

            }

            //Assert
            Assert.AreEqual(name, testName);

        }

    }
}

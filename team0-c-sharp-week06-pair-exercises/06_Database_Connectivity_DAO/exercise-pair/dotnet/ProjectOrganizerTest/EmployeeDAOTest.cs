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
    public class EmployeeDAOTest
    {
        EmployeeSqlDAO employeeSqlDAO;

        private string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=EmployeeDB;Integrated Security=True";

        private TransactionScope tran;

        [TestInitialize]
        public void Setup()
        {
            tran = new TransactionScope();
            //Arrange
            employeeSqlDAO = new EmployeeSqlDAO(connectionString);
        }

        [TestCleanup]
        public void Cleanup()
        {
            tran.Dispose();
        }

        [TestMethod]
        public void GetEmployeesTest()
        {
            //Act
            IList<Employee> employees = employeeSqlDAO.GetAllEmployees();
            //Assert
            Assert.IsNotNull(employees);

        }

        [TestMethod]
        [DataRow("Fredrick", "Keppard")]
        [DataRow("Chris", "Christie")]
        [DataRow("Jammie", "Mohl")]
        [DataRow("Sid", "Goodman")]
        [DataRow("Meg", "Buskirk")]
        public void SearchTestFullName(string firstName, string lastName)
        {
            //Act
           IList<Employee> test =  employeeSqlDAO.Search(firstName, lastName);

            //Assert
            foreach (Employee employee in test)
            {
                Assert.AreEqual(employee.FirstName, firstName);
                Assert.AreEqual(employee.LastName, lastName);
            }

        }

        [TestMethod]
        public void SearchTestPartialName()
        {
            //Act
            IList<Employee> test = employeeSqlDAO.Search("f", "e");
            string[] firstName = new string[3];
            firstName[0] = "Fredrick";
            firstName[1] = "Flo";
            firstName[2] = "Franklin";
            string[] lastName = new string[3];
            lastName[0] = "Keppard";
            lastName[1] = "Henderson";
            lastName[2] = "Trumbauer";

            //Assert
            int count = -1;
            foreach (Employee employee in test)
            {
                count++;
                Assert.AreEqual(employee.FirstName, firstName[count]);
                Assert.AreEqual(employee.LastName, lastName[count]);
            }

        }

        [TestMethod]
        public void GetEmployeesWithoutProjectsTest()       //only checked against null as employees without projects subject to change in console program.
        {
            //Act
            IList<Employee> test = employeeSqlDAO.GetEmployeesWithoutProjects();
            //Assert
            Assert.IsNotNull(test);
        }


    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetInfo;
using PetInfo.Classes.DAO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Transactions;

namespace PetInfoTest
{
    [TestClass]
    public class PetDAOTest
    {
        PetDAO petDAO;
        private string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=PetInfo;Integrated Security=True";
        //Transaction tran = new Transaction();


        [TestInitialize]
        public void Setup()
        {
            // Arrange
            petDAO = new PetDAO(connectionString);
        }

        [TestCleanup]
        public void Cleanup()
        {
            //tran.Dispose();
        }

        [TestMethod]
        public void PetDAOConstructor()
        {
            Assert.IsNotNull(petDAO);
        }

        [TestMethod]
        [DataRow("Dog 1", "dog", "All American")]
        public void PetWorksAddPet(string name, string type, string breed)
        {
            //Act
            petDAO.AddPet(name, type, breed);
            List<Pet> pets = petDAO.GetPets();

            //Assert
            Assert.AreEqual(name, pets[0].Name);
        }

        [TestMethod]
        public void PetDAODeletePet()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO pet (name, type, breed) Values " + "('Test Dog', 'dog', 'All American');", conn);

                int count = cmd.ExecuteNonQuery();

                cmd = new SqlCommand(
                    "SELECT id FROM pet WHERE name = 'Test Dog';");

                SqlDataReader reader = cmd.ExecuteReader();

                int testId = 0;
                if (reader.Read())
                {
                    testId = Convert.ToInt32(reader["id"]);
                }
                bool result = false;
                if (testId > 0)
                {
                    result = petDAO.DeletePet(testId);
                }

                Assert.IsTrue(result);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using Capstone.DAO.Interfaces;
using Capstone.Models;
using Capstone.Security;
using Capstone.Security.Models;

namespace Capstone.DAO
{
    public class UserSqlDAO : IUserDAO
    {
        private readonly string connectionString;

        private readonly string sqlGetUserByName = "SELECT user_id, username,  email, password_hash, salt, password_reset_code, user_role FROM users WHERE username = @username";
        private readonly string sqlGetUserById = "SELECT user_id, username,  email, password_hash, salt, password_reset_code, user_role FROM users WHERE user_id = @userId";
        private readonly string sqlGetUsers = "SELECT user_id, username, email, password_reset_code, user_role FROM users";
        private readonly string sqlGetUserByPWResetCode = "SELECT user_id, email, username, password_reset_code, password_hash, salt, user_role FROM users WHERE password_reset_code = @resetCode";
        private readonly string sqlGetUserByEmailAddress = "SELECT user_id, email, username, password_reset_code, password_hash, salt, user_role FROM users WHERE email = @email";


        public UserSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public User GetUser(string username)
        {
            User returnUser = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlGetUserByName, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        returnUser = GetUserFromReader(reader);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return returnUser;
        }
        public User GetUser(int userId)
        {
            User returnUser = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlGetUserById, conn);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        returnUser = GetUserFromReader(reader);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return returnUser;
        }

        public List<User> GetUsers()
        {
            List<User> users = new List<User>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlGetUsers, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        User user = GetLimitedUserFromReader(reader);
                        users.Add(user);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return users;
        }



        public User AddUser(string username, string email, string password, string role)
        {
            IPasswordHasher passwordHasher = new PasswordHasher();
            PasswordHash hash = passwordHasher.ComputeHash(password);

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string randomString = Path
                        .GetRandomFileName()
                        .Replace(".", "");
                    SqlCommand cmd = new SqlCommand("INSERT INTO users (username, email, password_hash, salt, password_reset_code, user_role) VALUES (@username, @email, @password_hash, @salt, @resetCode, @user_role)", conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password_hash", hash.Password);
                    cmd.Parameters.AddWithValue("@salt", hash.Salt);
                    cmd.Parameters.AddWithValue("@resetCode", randomString);
                    cmd.Parameters.AddWithValue("@user_role", role);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return GetUser(username);
        }

        private User GetUserFromReader(SqlDataReader reader)
        {
            User u = new User()
            {
                UserId = Convert.ToInt32(reader["user_id"]),
                Username = Convert.ToString(reader["username"]),
                PasswordHash = Convert.ToString(reader["password_hash"]),
                Salt = Convert.ToString(reader["salt"]),
                PasswordResetCode = Convert.ToString(reader["password_reset_code"]),
                Role = Convert.ToString(reader["user_role"]),
            };

            return u;
        }

        private User GetLimitedUserFromReader(SqlDataReader reader)
        {
            User u = new User()
            {
                UserId = Convert.ToInt32(reader["user_id"]),
                Email = Convert.ToString(reader["email"]),
                PasswordResetCode = Convert.ToString(reader["password_reset_code"]),
                Username = Convert.ToString(reader["username"]),
                Role = Convert.ToString(reader["user_role"]),
            };

            return u;
        }

        public User GetUserFromPWResetCode(string passwordResetCode)
        {
            User returnUser = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlGetUserByPWResetCode, conn);
                    cmd.Parameters.AddWithValue("@resetCode", passwordResetCode);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        returnUser = GetLimitedUserFromReader(reader);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return returnUser;
        }

        public string GetUserResetCodeFromEmail(string emailAddress)
        {
            string resetCode = "";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlGetUserByEmailAddress, conn);
                    cmd.Parameters.AddWithValue("@email", emailAddress);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        resetCode = Convert.ToString(reader["password_reset_code"]);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return resetCode;
        }
    }
}

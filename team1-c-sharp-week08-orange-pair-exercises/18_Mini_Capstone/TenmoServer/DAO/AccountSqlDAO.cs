using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TenmoServer.Models;
using System.Transactions;

namespace TenmoServer.DAO
{
    public class AccountSqlDAO : IAccountDAO
    {
        private readonly string connectionString;

        private string sqlGetBalanceQuery = "SELECT balance FROM accounts WHERE user_id = @id";
        private string sqlGetAccountIdFromUserId = "SELECT account_id FROM accounts WHERE user_id = @id";

        public AccountSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public decimal GetBalance(int id)
        {
            decimal currentBalance = -1.0M;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlGetBalanceQuery, conn);
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    currentBalance = Convert.ToDecimal(reader["balance"]);
                }

            }

            return currentBalance;
        }

        public int GetAccountIdFromUserId(int userId)
        {
            int accountId = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlGetAccountIdFromUserId, conn);
                cmd.Parameters.AddWithValue("@id", userId);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    accountId = Convert.ToInt32(reader["account_id"]);
                }

            }

            return accountId;
        }

    }
}

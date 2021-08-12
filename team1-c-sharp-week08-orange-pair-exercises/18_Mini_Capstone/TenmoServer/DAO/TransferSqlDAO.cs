using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TenmoServer.Models;
using System.Transactions;
using TenmoServer.DAO;

namespace TenmoServer.DAO
{
    public class TransferSqlDAO : ITransferDAO
    {
        private readonly string connectionString;
        private IAccountDAO accountDAO;
        private Dictionary<int, string> statusCodes = new Dictionary<int, string>()
        {
            {2000, "Pending"},
            {2001, "Approved"},
            {2002, "Rejected"}
        };
        private Dictionary<int, string> transferTypes = new Dictionary<int, string>()
        {
            {1000, "Request"},
            {1001, "Send"},
        };
        public TransferSqlDAO(IAccountDAO _accountDAO, string dbConnectionString)
        {
            accountDAO = _accountDAO;
            connectionString = dbConnectionString;
        }


        private string sqlAddTransferSendQuery = "INSERT INTO transfers (transfer_type_id, transfer_status_id, account_from, account_to, amount) "
                                               + "VALUES (1001, 2001, (SELECT account_id FROM accounts WHERE user_id = @senderId), (SELECT account_id FROM accounts WHERE user_id = @recipientId), @amount);";
        private string sqlWithdrawQuery = "UPDATE accounts SET balance = @newSenderBalance WHERE user_id = @senderId";
        private string sqlDepositQuery = "UPDATE accounts SET balance = @newRecipBalance WHERE user_id = @recipientId";
        private string sqlGetAcceptedSentTransfers = "SELECT * FROM users "
                                               + "JOIN accounts ON accounts.user_id = users.user_id "
                                               + "JOIN transfers ON transfers.account_from = accounts.account_id "
                                               + "WHERE (transfers.account_from = @id) AND transfer_status_id = 2001 "
                                               + "ORDER BY transfer_id";
        private string sqlGetAcceptedReceivedTransfers = "SELECT * FROM users "
                                       + "JOIN accounts ON accounts.user_id = users.user_id "
                                       + "JOIN transfers ON transfers.account_to = accounts.account_id "
                                       + "WHERE (transfers.account_to = @id) AND transfer_status_id = 2001 "
                                       + "ORDER BY transfer_id";

        public bool TransferTEBucks(int senderId, TransferDetails transferDetails)
        {
            decimal recipBalance = accountDAO.GetBalance(transferDetails.RecipientId);
            decimal senderBalance = accountDAO.GetBalance(senderId);
            bool success = false;

            using (TransactionScope tran = new TransactionScope())
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlWithdrawQuery, conn);
                    cmd.Parameters.AddWithValue("@newSenderBalance", senderBalance - transferDetails.TransferAmount);
                    cmd.Parameters.AddWithValue("@senderId", senderId);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows == 0)
                    {
                        tran.Dispose();
                    }
                    else
                    {
                        cmd = new SqlCommand(sqlDepositQuery, conn);
                        cmd.Parameters.AddWithValue("@newRecipBalance", recipBalance + transferDetails.TransferAmount);
                        cmd.Parameters.AddWithValue("@recipientId", transferDetails.RecipientId);
                        rows = cmd.ExecuteNonQuery();
                        if (rows == 0)
                        {
                            tran.Dispose();
                        }
                        else
                        {
                            AddSendRecord(senderId, transferDetails, conn);
                        }
                    }
                }
                tran.Complete();
                success = true;
            }

            return success;
        }

        public List<TransferDetails> GetAcceptedTransfers(int userId)
        {
            List<TransferDetails> acceptedTransfers = new List<TransferDetails>();
            int userAccountId = accountDAO.GetAccountIdFromUserId(userId);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlGetAcceptedSentTransfers, conn);
                cmd.Parameters.AddWithValue("@id", userAccountId);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    acceptedTransfers.Add(ReadTransferDetails(reader));
                }
                reader.Close();

                cmd = new SqlCommand(sqlGetAcceptedReceivedTransfers, conn);
                cmd.Parameters.AddWithValue("@id", userAccountId);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    acceptedTransfers.Add(ReadTransferDetails(reader));
                }
            }

            return acceptedTransfers;
        }

        public TransferDetails ReadTransferDetails(SqlDataReader reader)
        {
            TransferDetails transfer = new TransferDetails();

            transfer.RecipientId = Convert.ToInt32(reader["account_to"]);
            transfer.SenderId = Convert.ToInt32(reader["account_from"]);
            transfer.TransferId = Convert.ToInt32(reader["transfer_id"]);
            transfer.TransferAmount = Convert.ToDecimal(reader["amount"]);
            transfer.Status = statusCodes[Convert.ToInt32(reader["transfer_status_id"])];
            transfer.Type = transferTypes[Convert.ToInt32(reader["transfer_type_id"])];


            return transfer;
        }

        public bool AddSendRecord(int senderId, TransferDetails transferDetails, SqlConnection conn)
        {
            bool success = false;


            SqlCommand cmd = new SqlCommand(sqlAddTransferSendQuery, conn);
            cmd.Parameters.AddWithValue("@senderId", senderId);
            cmd.Parameters.AddWithValue("@recipientId", transferDetails.RecipientId);
            cmd.Parameters.AddWithValue("@amount", transferDetails.TransferAmount);
            int rows = cmd.ExecuteNonQuery();
            if (rows > 0)
            {
                success = true;
            }

            return success;
        }
    }
}

using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using TenmoClient.Data;

namespace TenmoClient.APIClients
{
    public class TransferService : AuthService
    {
        private const string API_BASE_URL = "https://localhost:44315/";

        public TransferDetails TransferTEBucks(int recipientId, decimal amount)
        {
            TransferDetails transfer = new TransferDetails { RecipientId = recipientId, TransferAmount = amount };

            RestRequest request = new RestRequest(API_BASE_URL + "transfer");
            request.AddJsonBody(transfer);
            IRestResponse<TransferDetails> response = client.Post<TransferDetails>(request);
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                throw new Exception("Error occurred - unable to reach server.");
            }
            else if (!response.IsSuccessful)
            {
                throw new Exception("Error occurred - received non-success response: " + (int)response.StatusCode);
            }
            else
            {
                return response.Data;
            }

        }

        public List<TransferDetails> GetPastTransfers()
        {
            RestRequest request = new RestRequest(API_BASE_URL + "transfer/past");
            IRestResponse<List<TransferDetails>> response = client.Get<List<TransferDetails>>(request);
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                throw new Exception("Error occurred - unable to reach server.");
            }
            else if (!response.IsSuccessful)
            {
                throw new Exception("Error occurred - received non-success response: " + (int)response.StatusCode);
            }
            else
            {
                return response.Data;
            }
        }
    }
}

using RestSharp;
using RestSharp.Authenticators;
using System;
using TenmoClient.Data;

namespace TenmoClient.APIClients
{
    public class AccountService : AuthService
    {
        private const string API_BASE_URL = "https://localhost:44315/";

        public decimal GetBalance()
        {
            RestRequest request = new RestRequest(API_BASE_URL + "account/balance");
            IRestResponse<decimal> response = client.Get<decimal>(request);
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

        public int GetCurrentAccountId()
        {
            RestRequest request = new RestRequest(API_BASE_URL + $"account/id");
            IRestResponse<int> response = client.Get<int>(request);
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

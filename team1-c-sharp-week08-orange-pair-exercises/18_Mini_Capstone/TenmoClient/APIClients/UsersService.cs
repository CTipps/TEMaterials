using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using TenmoClient.Data;

namespace TenmoClient.APIClients
{
    public class UsersService : AuthService
    {
        private const string API_BASE_URL = "https://localhost:44315/";

        public List<API_User> GetUsers()
        {
            RestRequest request = new RestRequest(API_BASE_URL + "users");
            IRestResponse<List<API_User>> response = client.Get<List<API_User>>(request);
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

        public API_User GetUserByAccountId(int accountId)
        {
            RestRequest request = new RestRequest(API_BASE_URL + $"users/{accountId}");
            IRestResponse<API_User> response = client.Get<API_User>(request);
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

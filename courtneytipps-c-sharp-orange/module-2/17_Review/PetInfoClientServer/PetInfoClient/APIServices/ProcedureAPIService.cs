using PetInfoClient.Models;
using RestSharp;
using System;
using System.Collections.Generic;


namespace PetInfoClient.APIServices
{
    class ProcedureAPIService : LoginAPIService
    {
        private readonly string API_URL = "https://localhost:44349/procedure/";

        public List<Procedure> GetProcedures()
        {
            //List<Procedure> cities = new List<Procedure>();

            RestRequest request = new RestRequest(API_URL);
            IRestResponse<List<Procedure>> response = client.Get<List<Procedure>>(request);
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

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AdultsClient.Models;

namespace AdultsClient.Data
{
    public class CloudAdultService : IAdultsService
    {
        private string uri = "https://localhost:5001";
        private readonly HttpClient client;
        private HttpClientHandler clientHandler;

        public CloudAdultService()
        {
           
            clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
            client = new HttpClient(clientHandler);  
        }
        
        public async Task AddAdultsAsync(Adult adult)
        {
            string adultAsJson = JsonSerializer.Serialize(adult);
            HttpContent content = new StringContent(adultAsJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(uri + "/Adults", content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error, {response.StatusCode}, {response.ReasonPhrase}");
            }
        }

        public async Task<IList<Adult>> GetAdultsAsync()
        {
            HttpResponseMessage response = await client.GetAsync(uri + "/Adults");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Not good");
            }

            string message = await response.Content.ReadAsStringAsync();
            List<Adult> result = JsonSerializer.Deserialize<List<Adult>>(message);
            return result;
        }

        public async Task RemoveAdultAsync(int AdultId)
        {
            HttpResponseMessage response = await client.DeleteAsync($"{uri}/Adults/{AdultId}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error, {response.StatusCode}, {response.ReasonPhrase}");
            }
        }
    }
}
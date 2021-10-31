using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using AdultsClient.Models;

namespace AdultsClient.Data
{
    public class UserWebService : IUserService
    {
        private string uri = "https://localhost:5001";
        private readonly HttpClient client;
        private HttpClientHandler clientHandler;

        public UserWebService()
        {
           
            clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
            client = new HttpClient(clientHandler);  
        }
        public async Task<User> ValidateUserAsync(string username, string password)
        {
            Console.WriteLine($"{username}, {password}");
            HttpResponseMessage response = await client.GetAsync($"{uri}/Users?username={username}&password={password}");
   
            if (response.StatusCode == HttpStatusCode.OK)
            {
                    string userAsJson = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(userAsJson);
                    User resultUser = JsonSerializer.Deserialize<User>(userAsJson, new JsonSerializerOptions()
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });
                    Console.WriteLine(resultUser.UserName);
                    return resultUser;
            }
            else
            {
                Console.WriteLine(response.StatusCode);
                Console.WriteLine("Querry not ok");
            }
            throw new Exception("User not found");
        }
    }
}
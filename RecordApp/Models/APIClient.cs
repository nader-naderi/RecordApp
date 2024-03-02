using System.Net.Http;
using System.Text;

using Newtonsoft.Json;

using SharedData;

namespace RecordApp.Models
{
    public class APIClient
    {
        private static HttpClient _httpClient;
        private static string _apiBaseUrl = "https://localhost:7186"; // Replace <port> with the port number of your API service

        public APIClient()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(_apiBaseUrl) };
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("/person/GetAllUsers");
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<User>>(responseBody);
        }

        public async Task AddNewUserAsync(string name, string email)
        {
            // Create a new user object with the provided name and email
            var user = new User
            {
                Name = name,
                Email = email
            };

            string userJson = JsonConvert.SerializeObject(user);
            StringContent content = new StringContent(userJson, Encoding.UTF8, "application/json");

            // Send a POST request to the API to add the new user
            HttpResponseMessage response = await _httpClient.PostAsync("/person/AddNewUser", content);
            response.EnsureSuccessStatusCode();
        }
        public async Task DeleteUserAsync(int id)
        {
            // Send a DELETE request to the API to delete the user
            HttpResponseMessage response = await _httpClient.DeleteAsync($"/person/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateUserAsync(int id, User user)
        {
            string userJson = JsonConvert.SerializeObject(user);
            StringContent content = new StringContent(userJson, Encoding.UTF8, "application/json");

            // Send a PUT request to the API to update the user
            HttpResponseMessage response = await _httpClient.PutAsync($"/person/{id}", content);
            response.EnsureSuccessStatusCode();
        }
    }
}

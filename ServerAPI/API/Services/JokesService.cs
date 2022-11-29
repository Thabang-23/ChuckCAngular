using System.Text.Json;
using API.Models;

namespace API.Services
{
    public class JokesService
    {
        private readonly HttpClient _client;
        private readonly ILogger<JokesService> _logger;
        private readonly IConfiguration _config;

        public JokesService(HttpClient client, ILogger<JokesService> logger, IConfiguration config)
        {
            _config = config;
            _client = client;
            _logger = logger;
        }

        public async Task<string> GetCategoriesResponseAsync()
        {
            var BaseUrl = _config["ChuckNorris"];
            var httpResponseMessage = await _client.GetStringAsync($"{BaseUrl}/categories");

            return httpResponseMessage;
        }

        public async Task<JokeResponse> GetRandomJokeAsync(string category)
        {
            JokeResponse result = new JokeResponse();
            var BaseUrl = _config["ChuckNorris"];
            var httpResponseMessage = await _client.GetAsync($"{BaseUrl}/random?category={category}");

            httpResponseMessage.EnsureSuccessStatusCode();

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var jsonString = await httpResponseMessage.Content.ReadAsStringAsync();
                result = JsonSerializer.Deserialize<JokeResponse>(jsonString, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }

            return result;
        }
    }
}
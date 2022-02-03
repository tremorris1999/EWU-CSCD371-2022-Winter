using System.Text.Json;
using System.Net.Http;

namespace CanHazFunny
{
    public class JokeService: IJokable
    {
        private HttpClient HttpClient { get; } = new();

        public string GetJoke()
        {
            string dump = HttpClient.GetStringAsync("https://geek-jokes.sameerkumar.website/api?format=json").Result;
            return JsonDocument.Parse(dump).RootElement.GetProperty("joke").ToString();
        }
    }
}

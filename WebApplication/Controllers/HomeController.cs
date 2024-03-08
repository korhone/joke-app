using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;
using Newtonsoft.Json;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _client;

        public HomeController()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://official-joke-api.appspot.com/"); // API URL

        }
        // Get Joke to view
        public async Task<ActionResult> Index()
        {
            var joke = await GetJoke();
            return View(joke);
        }
        private async Task<Joke> GetJoke()
        {
            Joke joke = null;
            HttpResponseMessage response = await _client.GetAsync("/random_joke"); // ENDPOINT 

            if (response.IsSuccessStatusCode)
            {
                // waits answer 
                var jokeString = await response.Content.ReadAsStringAsync();
                // deserialize JSON 
                joke = JsonConvert.DeserializeObject<Joke>(jokeString);
            }
            // return joke to GUI
            return joke;
        }
    }
}

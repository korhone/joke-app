namespace WebApplication1.Models
{
    // API returns a joke with type, setup, punchline and id
    // getters and setters:
    public class Joke
    {
        public string type { get; set; }
        public string setup { get; set; }
        public string punchline { get; set; }
        public int id { get; set; }
    }
}

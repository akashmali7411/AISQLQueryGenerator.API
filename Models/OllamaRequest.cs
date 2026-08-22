namespace AISQLQueryGenerator.API.Models
{
    public class OllamaRequest
    {
        public string Model { get; set; } = "gemma3:4b";
        public string Prompt { get; set; } = string.Empty;
        public bool Stream { get; set; } = false;
    }
}
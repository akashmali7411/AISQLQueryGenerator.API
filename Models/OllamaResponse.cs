using System.Text.Json.Serialization;

namespace AISQLQueryGenerator.API.Models
{
    public class OllamaResponse
    {
        [JsonPropertyName("response")]
        public string Response { get; set; } = string.Empty;
    }
}
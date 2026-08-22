using AISQLQueryGenerator.API.Extensions;
using AISQLQueryGenerator.API.Interfaces;
using AISQLQueryGenerator.API.Models;
using AISQLQueryGenerator.API.Prompts;
using System.Text;
using System.Text.Json;

namespace AISQLQueryGenerator.API.Services
{
    public class AIService : IAIService
    {
        private readonly HttpClient _httpClient;

        public AIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Generic AI Prompt
        public async Task<string> GenerateAsync(string prompt)
        {
            var request = new OllamaRequest
            {
                Model = "gemma3:4b",
                Prompt = prompt,
                Stream = false
            };

            var json = JsonSerializer.Serialize(request);

            var content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync(
                "http://localhost:11434/api/generate",
                content);

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();

            var ollamaResponse =
                JsonSerializer.Deserialize<OllamaResponse>(result);

            return ollamaResponse?.Response ?? "";
        }


        // SQL Generator
        public async Task<string> GenerateSqlAsync(
            string database,
            string description,
            string? schema)
        {
            // Build AI prompt with Database + Description + Schema
            var prompt = SqlPrompt.BuildPrompt(
                database,
                description,
                schema);

            // Send prompt to Ollama
            var response = await GenerateAsync(prompt);

            // Clean AI response
            response = SqlCleaner.Clean(response);

            return response;
        }
    }
}
namespace AISQLQueryGenerator.API.DTOs
{
    public class GenerateSqlRequest
    {
        public string Database { get; set; } = "MySQL";
        public string Description { get; set; } = string.Empty;

        public string? Schema { get; set; }
    }
}
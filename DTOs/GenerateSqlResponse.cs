namespace AISQLQueryGenerator.API.DTOs
{
    public class GenerateSqlResponse
    {
        public bool Success { get; set; }

        public string Database { get; set; }

        public string QueryType { get; set; }

        public string Sql { get; set; }

        public string Message { get; set; }
    }
}
using AISQLQueryGenerator.API.Entities;

namespace AISQLQueryGenerator.API.DTOs
{
    public class UploadSchemaResponse
    {
        public bool Success { get; set; }

        public int TableCount { get; set; }

        public int ColumnCount { get; set; }

        public List<TableInfo> Tables { get; set; } = new();

        public string Message { get; set; } = "";
    }
}
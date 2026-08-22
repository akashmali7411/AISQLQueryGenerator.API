namespace AISQLQueryGenerator.API.Entities
{
    public class ColumnInfo
    {
        public string ColumnName { get; set; } = string.Empty;

        public string DataType { get; set; } = string.Empty;

        public bool IsPrimaryKey { get; set; }

        public bool IsNullable { get; set; }
    }
}
namespace AISQLQueryGenerator.API.Entities
{
    public class TableInfo
    {
        public string TableName { get; set; } = string.Empty;

        public List<ColumnInfo> Columns { get; set; } = new();
    }
}
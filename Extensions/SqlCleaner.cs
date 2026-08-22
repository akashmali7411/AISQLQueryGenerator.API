namespace AISQLQueryGenerator.API.Extensions
{
    public static class SqlCleaner
    {
        public static string Clean(string sql)
        {
            if (string.IsNullOrWhiteSpace(sql))
                return string.Empty;

            sql = sql.Replace("```sql", "")
                     .Replace("```", "")
                     .Replace("Here is your SQL:", "")
                     .Replace("Generated SQL:", "")
                     .Replace("\\r", "")
                     .Replace("\\n", Environment.NewLine)
                     .Replace("\\t", "\t")
                     .Trim();

            return sql;
        }
    }
}
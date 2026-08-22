namespace AISQLQueryGenerator.API.Extensions
{
    public static class QueryTypeDetector
    {
        public static string Detect(string sql)
        {
            sql = sql.Trim().ToUpper();

            if (sql.StartsWith("SELECT"))
                return "SELECT";

            if (sql.StartsWith("INSERT"))
                return "INSERT";

            if (sql.StartsWith("UPDATE"))
                return "UPDATE";

            if (sql.StartsWith("DELETE"))
                return "DELETE";

            if (sql.StartsWith("CREATE"))
                return "CREATE";

            if (sql.StartsWith("ALTER"))
                return "ALTER";

            if (sql.StartsWith("DROP"))
                return "DROP";

            return "UNKNOWN";
        }
    }
}
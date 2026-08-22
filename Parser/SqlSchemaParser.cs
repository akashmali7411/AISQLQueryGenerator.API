using System.Text.RegularExpressions;
using AISQLQueryGenerator.API.Entities;

namespace AISQLQueryGenerator.API.Parser
{
    public static class SqlSchemaParser
    {
        public static List<TableInfo> Parse(string sqlScript)
        {
            var tables = new List<TableInfo>();

            if (string.IsNullOrWhiteSpace(sqlScript))
                return tables;

            var tablePattern =
                @"CREATE\s+TABLE\s+(\w+)\s*\((.*?)\);";

            var tableMatches = Regex.Matches(
                sqlScript,
                tablePattern,
                RegexOptions.Singleline | RegexOptions.IgnoreCase);

            foreach (Match tableMatch in tableMatches)
            {
                var table = new TableInfo();

                table.TableName = tableMatch.Groups[1].Value;

                string body = tableMatch.Groups[2].Value;

                string[] lines = body.Split(',');

                foreach (var line in lines)
                {
                    var column = ParseColumn(line);

                    if (column != null)
                        table.Columns.Add(column);
                }

                tables.Add(table);
            }

            return tables;
        }

        private static ColumnInfo? ParseColumn(string line)
        {
            line = line.Trim();

            if (string.IsNullOrWhiteSpace(line))
                return null;

            if (line.StartsWith("PRIMARY KEY",
                StringComparison.OrdinalIgnoreCase))
                return null;

            if (line.StartsWith("FOREIGN KEY",
                StringComparison.OrdinalIgnoreCase))
                return null;

            var parts = line.Split(
                ' ',
                StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length < 2)
                return null;

            return new ColumnInfo
            {
                ColumnName = parts[0],

                DataType = parts[1],

                IsPrimaryKey =
                    line.Contains("PRIMARY KEY",
                    StringComparison.OrdinalIgnoreCase),

                IsNullable =
                    !line.Contains("NOT NULL",
                    StringComparison.OrdinalIgnoreCase)
            };
        }
    }
}
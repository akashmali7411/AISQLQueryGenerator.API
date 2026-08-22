using AISQLQueryGenerator.API.Entities;
using AISQLQueryGenerator.API.Interfaces;
using AISQLQueryGenerator.API.Parser;

namespace AISQLQueryGenerator.API.Services
{
    public class SchemaService : ISchemaService
    {
        public List<TableInfo> Parse(string sqlScript)
        {
            return SqlSchemaParser.Parse(sqlScript);
        }
    }
}
using AISQLQueryGenerator.API.Entities;

namespace AISQLQueryGenerator.API.Interfaces
{
    public interface ISchemaService
    {
        List<TableInfo> Parse(string sqlScript);
    }
}
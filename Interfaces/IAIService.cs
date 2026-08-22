using System.Threading.Tasks;

namespace AISQLQueryGenerator.API.Interfaces
{
    public interface IAIService
    {
        Task<string> GenerateAsync(string prompt);

        Task<string> GenerateSqlAsync(
            string database,
            string description,
            string? schema);
    }
}
using AISQLQueryGenerator.API.DTOs;
using AISQLQueryGenerator.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AISQLQueryGenerator.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SqlController : ControllerBase
    {
        private readonly IAIService _aiService;

        public SqlController(IAIService aiService)
        {
            _aiService = aiService;
        }

        [HttpPost("generate")]
        public async Task<IActionResult> Generate(
            [FromBody] GenerateSqlRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Description))
            {
                return BadRequest("Please enter a valid description.");
            }

            var sql = await _aiService.GenerateSqlAsync(
                request.Database,
                request.Description,
                request.Schema);

            return Ok(new GenerateSqlResponse
            {
                Success = true,
                Sql = sql
            });
        }
    }
}
using AISQLQueryGenerator.API.DTOs;
using AISQLQueryGenerator.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AISQLQueryGenerator.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SchemaController : ControllerBase
    {
        private readonly ISchemaService _schemaService;

        public SchemaController(ISchemaService schemaService)
        {
            _schemaService = schemaService;
        }

        [HttpPost("upload")]
        public IActionResult UploadSchema([FromBody] UploadSchemaRequest request)
        {
            var tables = _schemaService.Parse(request.SqlScript);

            var response = new UploadSchemaResponse
            {
                Success = true,

                TableCount = tables.Count,

                ColumnCount = tables.Sum(x => x.Columns.Count),

                Tables = tables,

                Message = "Schema Parsed Successfully"
            };

            return Ok(response);
        }
    }
}
using Core.Dtos.Reservation;
using Core.Interface.Reservation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace Api.Controllers.Reservation
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly ITableService _tableService;

        public TableController(ITableService tableService)
        {
            _tableService = tableService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllTables()
        {
            return await _tableService.GetTables();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetTableById(int id)
        {
            return await _tableService.GetTableById(id);
        }
        [HttpPost("Create")]
        [Authorize]
        public async Task<ActionResult> CreateTable([FromBody] TableDto tableDto)
        {
            return await _tableService.CreateTable(tableDto);
        }
        [HttpPut("Update/{id}")]
        [Authorize]
        public async Task<ActionResult> UpdateTable(int id, [FromBody] TableDto tableDto)
        {
            return await _tableService.UpdateTable(id, tableDto);
        }
        [HttpDelete("Delete/{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteTable(int id)
        {
            return await _tableService.DeleteTable(id);
        }
    }
}


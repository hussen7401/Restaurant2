using Core.Dtos;
using Core.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuItemService _menuService;

        public MenuController(IMenuItemService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMenuItems()
        {
            return await _menuService.GetMenuItems();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMenuItem(int id)
        {
            return await _menuService.GetMenuItemById(id);
        }
        [HttpGet("name/{name}")]
        public async Task<IActionResult> SearchMenuItemByName(string name)
        {
            return await _menuService.GetMenuItemByName(name);
        }
        [HttpPost("create")]
        //[Authorize(Roles = "SuperAdmin,Admin,Employee")] 
        public async Task<IActionResult> CreateMenuItem([FromBody] MenuItemDto menuItemDto)
        {
            return await _menuService.CreateMenuItem(menuItemDto);
        }
        [HttpPut("update/{id}")]
        //[Authorize(Roles = "SuperAdmin,Admin,Employee")] 
        public async Task<IActionResult> UpdateMenuItem(int id, [FromBody] MenuItemDto menuItemDto)
        {
            return await _menuService.UpdateMenuItem(id, menuItemDto);
        }
        [HttpDelete("delete/{id}")]
        //[Authorize(Roles = "SuperAdmin,Admin,Employee")] 
        public async Task<IActionResult> DeleteMenuItem(int id)
        {
            return await _menuService.DeleteMenuItem(id);
        }
    }
}

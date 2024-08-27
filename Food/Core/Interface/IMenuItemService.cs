using Core.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Core.Interface
{
    public interface IMenuItemService
    {
        Task<IActionResult> GetMenuItems();
        Task<IActionResult> GetMenuItemById(int id);
        Task<IActionResult> GetMenuItemByName(string name);
        Task<IActionResult> CreateMenuItem(MenuItemDto menuItemDto);
        Task<IActionResult> UpdateMenuItem(int id, MenuItemDto menuItemDto);
        Task<IActionResult> DeleteMenuItem(int id);
    }        
}

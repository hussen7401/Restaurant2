using Core.Dtos;
using Core.Entities;
using Core.Helper;
using Core.Interface;
using Core.Interface.Auth;
using Infrastructure.Data;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class MenuItemService : IMenuItemService
    {
        private readonly AppDbContext _context;
        private readonly Responses _responses;
        private readonly ITokenData _tokenData;

        public MenuItemService(AppDbContext context, Responses responses, ITokenData tokenData)
        {
            _context = context;
            _responses = responses;
            _tokenData = tokenData;
        }
        public async Task<IActionResult> GetMenuItems()
        {
            try
            {
                var ListMenuItem = await _context.MenuItems.ToListAsync();

                if (ListMenuItem == null || !ListMenuItem.Any())
                {
                    return _responses.ResponseNotFound("لا توجد بيانات للعرض!");
                }

                return _responses.ResponseSuccess("تم جلب البيانات بنجاح.", ListMenuItem);
            }
            catch (DbUpdateException ex)
            {
                return _responses.DatebaseExaption(ex);
            }
            catch (Exception ex)
            {
                return _responses.HandleException(ex);
            }
        }
        public async Task<IActionResult> GetMenuItemById(int id)
        {
            try
            {
                var menuItem = await _context.MenuItems.FindAsync(id);

                if (menuItem == null)
                {
                    return _responses.ResponseNotFound("الوجبة المطلوبة غير موجودة!");
                }

                return _responses.ResponseSuccess("تم جلب بيانات الوجبة بنجاح", menuItem);
            }
            catch (DbUpdateException ex)
            {
                return _responses.DatebaseExaption(ex);
            }
            catch (Exception ex)
            {
                return _responses.HandleException(ex);
            }
        }
        public async Task<IActionResult> GetMenuItemByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return _responses.ResponseBadRequest("اسم الوجبة مطلوب!");
            }
            try
            {
                var lowerCaseName = name.ToLower();

                var menuItems = await _context.MenuItems
                    .Where(mi => mi.Name.ToLower().Contains(lowerCaseName) && mi.IsAvailable)
                    .ToListAsync();

                if (menuItems.Count == 0)
                {
                    return _responses.ResponseNotFound("الوجبة المطلوبة غير موجودة!");
                }

                return _responses.ResponseSuccess("تم جلب بيانات الوجبات بنجاح.", menuItems);

            }
            catch (DbUpdateException ex)
            {
                return _responses.DatebaseExaption(ex);
            }
            catch (Exception ex)
            {
                return _responses.HandleException(ex);
            }
        }
        public async Task<IActionResult> CreateMenuItem(MenuItemDto menuItemDto)
        {
            try
            {
                #region Add MenuItem To DataBase
                var AddMenuItem = menuItemDto.Adapt<MenuItem>();
                AddMenuItem.CreateAt = DateTime.UtcNow;
                AddMenuItem.CreatorId = _tokenData.UserId();
                await _context.MenuItems.AddAsync(AddMenuItem);
                await _context.SaveChangesAsync();
                #endregion
                return _responses.ResponseSuccess("تم إنشاء الوجبة بنجاح.", AddMenuItem);

            }
            catch (DbUpdateException ex)
            {
                return _responses.DatebaseExaption(ex);
            }
            catch (Exception ex)
            {
                return _responses.HandleException(ex);
            }
        }
        public async Task<IActionResult> UpdateMenuItem(int id, MenuItemDto menuItemDto)
        {
            try
            {
                var menuItem = await _context.MenuItems.FindAsync(id);
                if (menuItem == null)
                {
                    return _responses.ResponseNotFound("الوجبة المطلوبة غير موجودة!");
                }


                #region Update MenuItem 
                menuItem.Name = menuItemDto.Name;
                menuItem.Description = menuItemDto.Description;
                menuItem.Price = menuItemDto.Price;
                menuItem.IsAvailable = menuItemDto.IsAvailable;
                menuItem.ModifiedAt = DateTime.UtcNow;
                menuItem.ModifierId = _tokenData.UserId();
                _context.MenuItems.Update(menuItem);
                await _context.SaveChangesAsync();
                #endregion
                return _responses.ResponseSuccess("تم تحديث بيانات الوجبة بنجاح.", menuItem);
            }
            catch (DbUpdateException ex)
            {
                return _responses.DatebaseExaption(ex);
            }
            catch (Exception ex)
            {
                return _responses.HandleException(ex);
            }
        }
        public async Task<IActionResult> DeleteMenuItem(int id)
        {
            try
            {
                var menuItem = await _context.MenuItems.FindAsync(id);
                if (menuItem == null)
                {
                    return _responses.ResponseNotFound("الوجبة المطلوبة غير موجودة!");
                }

                _context.MenuItems.Remove(menuItem);
                await _context.SaveChangesAsync();

                return _responses.ResponseSuccess("تم حذف الوجبة بنجاح.");
            }
            catch (DbUpdateException ex)
            {
                return _responses.DatebaseExaption(ex);
            }
            catch (Exception ex)
            {
                return _responses.HandleException(ex);
            }
        }

    }
}

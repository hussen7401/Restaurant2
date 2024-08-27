using Core.Dtos.User;
using Core.Entities;
using Core.Enums;
using Core.Helper;
using Core.Interface.Auth;
using Infrastructure.Data;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.Auth
{
    public class UserService : IUserService
    {
        private readonly ITokenData _tokenData;
        private readonly AppDbContext _context;
        private readonly Responses _responses;

        public UserService(ITokenData tokenData, AppDbContext context, Responses responses)
        {
            _tokenData = tokenData;
            _context = context;
            _responses = responses;
        }
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await _context.Users.ToListAsync();
                if (users == null || users.Count == 0)
                {
                    return _responses.ResponseNotFound("لا توجد حسابات للعرض.");
                }
                var ShowUsers = users.Adapt<List<ShowUser>>();

                return _responses.ResponseSuccess("تم جلب جميع الحسابات ", ShowUsers);

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
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var user = await _context.Users.FirstAsync(u => u.Id == id);
                if (user == null)
                {
                    return _responses.ResponseNotFound("لم يتم العثور على المستخدم.");
                }

                var showUserToAdmin = user.Adapt<ShowUserToAdmin>();

                return _responses.ResponseSuccess("تم جلب بيانات المستخدم بنجاح ", showUserToAdmin);

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
        public async Task<IActionResult> GetUserProfile(int id)
        {
            try
            {
                var user = await _context.Users.FindAsync(id);
                if (user == null)
                {
                    return _responses.ResponseNotFound("لم يتم العثور على المستخدم.");
                }
                var ShowUser= user.Adapt<ShowUser>();

                return _responses.ResponseSuccess("تم جلب بيانات المستخدم بنجاح ", ShowUser);

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
        public async Task<IActionResult> GetUserByUsername(string username)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
                if (user == null)
                {
                    return _responses.ResponseNotFound("لم يتم العثور على المستخدم.");
                }
                var ShowUser = user.Adapt<ShowUser>();

                return _responses.ResponseSuccess("تم جلب بيانات المستخدم بنجاح ", ShowUser);

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
        public async Task<IActionResult> UpdateUser(int userId, [FromBody] UpdateUser updateUser)
        {
            if (string.IsNullOrWhiteSpace(updateUser.FirstName)
            || string.IsNullOrWhiteSpace(updateUser.LastName)
               || string.IsNullOrWhiteSpace(updateUser.UserName))
            {
                return _responses.ResponseBadRequest("البيانات المدخلة غير صحيحة");
            }
            try
            {
                var id = _tokenData.UserId();
                if (userId != id)
                {
                    return _responses.ResponseUnauthorized("لا تملك صلاحية تعديل هذا الحساب.");
                }
                else
                {
                    if (await _context.Users.AnyAsync(u => u.UserName == updateUser.UserName))
                    {
                        return _responses.ResponseConflict("اسم المستخدم موجود بالفعل.");
                    }
                    if (await _context.Users.AnyAsync(u => u.Email == updateUser.Email))
                    {
                        return _responses.ResponseConflict("البريد الالكتروني مسجل مسبقاً.");
                    }

                    #region Update User Data
                    var user = updateUser.Adapt<User>();
                    user.ModifiedAt = DateTime.UtcNow;
                    await _context.Users.AddAsync(user);
                    await _context.SaveChangesAsync();
                    var ShowUser = user.Adapt<ShowUser>();
                    #endregion
                    return _responses.ResponseSuccess("تم تحديث البيانات بنجاح .", ShowUser);
                }
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
        public async Task<IActionResult> DeleteUser(int userId)
        {
            if (await _tokenData.Role() == UserRoles.SuperAdmin.ToString() || await _tokenData.Role() == UserRoles.Admin.ToString())
            {
                try
                {
                    var user = await _context.Users.FindAsync(userId);
                    if (user == null)
                    {
                        return _responses.ResponseNotFound("لم يتم العثور على المستخدم.");
                    }
                    if (user.IsDeleted)
                    {
                        return _responses.ResponseUnauthorized("الحساب محذوف مؤخراً.");
                    }

                    #region Delete User
                    user.IsDeleted = true;
                    user.DeletedAt = DateTime.UtcNow;
                    user.DeleterId = _tokenData.UserId();
                    user.Token = null;
                    user.IsLocked = true;
                    _context.Users.Update(user);
                    await _context.SaveChangesAsync();
                    #endregion
                    return _responses.ResponseSuccess("تم حذف المستخدم بنجاح.");
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
            return _responses.ResponseUnauthorized("لا تملك صلاحية لحذف المستخدم ");
        }

    }
}

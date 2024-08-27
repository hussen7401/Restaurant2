using Core.Dtos.User;
using Core.Helper;
using Core.Interface.Auth;
using Infrastructure.Data;
using Infrastructure.Security;
using Mapster;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Core.Enums;
using Core.Entities;

namespace Infrastructure.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly Responses _responses;
        private readonly IConfiguration _configuration;
        private readonly ITokenData _tokenData;

        public AuthService(AppDbContext context,
            Responses responses,
            IConfiguration configuration,
            ITokenData tokenData)
        {
            _context = context;
            _responses = responses;
            _configuration = configuration;
            _tokenData = tokenData;
        }

        public async Task<IActionResult> Register([FromBody] Register register)
        {
            if (string.IsNullOrWhiteSpace(register.FirstName)
                || string.IsNullOrWhiteSpace(register.LastName)
                || string.IsNullOrWhiteSpace(register.UserName))
            {
                return _responses.ResponseBadRequest("البيانات المدخلة غير صحيحة");
            }
            try
            {
                if (await _context.Users.AnyAsync(u => u.UserName == register.UserName))
                {
                    return _responses.ResponseConflict("اسم المستخدم موجود بالفعل.");
                }
                if (await _context.Users.AnyAsync(u => u.Email == register.Email))
                {
                    return _responses.ResponseConflict("البريد الالكتروني مسجل مسبقاً.");
                }

                #region Create User 
                var user = register.Adapt<User>();
                // Create Password Hash
                SecurityHelper security = new SecurityHelper();
                user.PasswordHash = security.HashPassword(register.Password!);

                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                #endregion
                return _responses.ResponseSuccess("تم انشاء حساب بنجاح", user);
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
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            if (string.IsNullOrWhiteSpace(login.UserOrEmail))
            {
                return _responses.ResponseBadRequest("البيانات المدخلة غير صحيحة ");
            }
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u =>
                u.UserName.ToLower() == login.UserOrEmail.ToLower() || u.Email.ToLower() == login.UserOrEmail.ToLower());
                if (user == null)
                {
                    return _responses.ResponseNotFound("المستخدم غير موجود.");
                }
                if (user.IsDeleted)
                {
                    return _responses.ResponseBadRequest(" المستخدم محذوف.");
                }
                if (user.IsLocked && user.LockTime == null)
                {
                    return _responses.ResponseUnauthorized("الحساب مقفل يرجى التواصل مع ادارة النظام");
                }
                if (user.IsLocked && user.LockTime > DateTime.UtcNow)
                {
                    return _responses.ResponseUnauthorized("تم قفل حسابك. يرجى المحاولة لاحقاً");
                }

                bool isPasswordValid = VerifyPassword(login.Password, user.PasswordHash!);
                if (!isPasswordValid)
                {
                    user.AccessFailedCount++;

                    if (user.AccessFailedCount >= 5)
                    {
                        user.IsLocked = true;
                        user.LockTime = DateTime.UtcNow.AddMinutes(10);
                    }

                    _context.Users.Update(user);
                    await _context.SaveChangesAsync();
                    return _responses.ResponseUnauthorized("كلمة المرور غير صحيحة.");
                }

                #region If the login seccess 

                // Update user lock data
                user.AccessFailedCount = 0;
                user.IsLocked = false;
                user.LockTime = null;

                // Generate Token 
                List<Claim> claims = new List<Claim>
                {
                    new Claim("userId", user.Id.ToString()),
                    new Claim("fullName", user.FullName),
                    new Claim("userName", user.UserName),
                    new Claim("role", user.Role.ToString())
                };
                var token = GenerateToken(claims);
                user.Token = token;
                // Update last login 
                user.LastLoginDate = DateTime.UtcNow;

                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                #endregion
                var a = user.Role.ToString();
                return _responses.ResponseSuccess("تم تسجيل الدخول بنجاح.}", token);
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
        public async Task<IActionResult> ForgetPassword(ForgetPassword forgetPassword)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == forgetPassword.Email);
                if (user == null)
                {
                    return _responses.ResponseNotFound("لم يتم العثور على المستخدم.");
                }
                if (user.IsDeleted)
                {
                    return _responses.ResponseBadRequest(" المستخدم محذوف.");
                }
                if (user.IsLocked && user.LockTime == null)
                {
                    return _responses.ResponseUnauthorized("الحساب مقفل يرجى التواصل مع ادارة النظام");
                }
                #region Generate Otp and Update data

                //  Generate One Time Token 
                Random random = new Random();
                int otp = random.Next(100000, 999999);
                var userId = user.Id;
                var token = $"{userId}{otp}";

                // Send the email with the token to the user
                //var subject = "Account Password Reset Notification";
                //var body = $"Hi, Your verification code is: {token}";
                if (user.Email != null)
                {
                    //Send the email code
                }

                user.OtpToken = Convert.ToInt32(token);
                user.OtpExpire = DateTime.UtcNow.AddMinutes(2);
                user.ModifierId = 1;
                user.ModifiedAt = DateTime.UtcNow;
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                #endregion

                return _responses.ResponseSuccess("تم إرسال رمز إعادة تعيين كلمة المرور إلى البريد الإلكتروني.", token);
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
        public async Task<IActionResult> ResetPassword(ResetPassword resetPassword)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.OtpToken == resetPassword.OtpToken && u.OtpExpire >= DateTime.UtcNow);
                if (user == null)
                {
                    return _responses.ResponseNotFound("رمز إعادة التعيين غير صالح أو منتهي الصلاحية.");
                }

                #region Set New Password 
                var security = new SecurityHelper();
                user.PasswordHash = security.HashPassword(resetPassword.NewPassword);

                user.OtpToken = null;
                user.OtpExpire = null;

                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                #endregion

                return _responses.ResponseSuccess("تم إعادة تعيين كلمة المرور بنجاح.");
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
        public async Task<IActionResult> ChangeUserRole(ChangeUserRole userRole)
        {
            try
            {
                if (await _tokenData.Role() == UserRoles.SuperAdmin.ToString() || await _tokenData.Role() == UserRoles.Admin.ToString())
                {
                    var user = await _context.Users.FindAsync(userRole.UserId);
                    if (user == null)
                    {
                        return _responses.ResponseNotFound("لم يتم العثور على المستخدم.");
                    }

                    #region Update User Role 
                    user.Role = userRole.NewRole;
                    user.ModifierId = _tokenData.UserId();
                    user.ModifiedAt = DateTime.Now;
                    _context.Users.Update(user);
                    await _context.SaveChangesAsync();
                    #endregion

                    return _responses.ResponseSuccess("تم تحديث دور المستخدم بنجاح.");
                }
                else
                {
                    return _responses.ResponseUnauthorized("لا تملك صلاحية تغيير دور المستخدم.");
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
        public async Task<IActionResult> ManageAccount(int userId, bool status)
        {
            try
            {
                if (await _tokenData.Role() == UserRoles.SuperAdmin.ToString() ||
                    await _tokenData.Role() == UserRoles.Admin.ToString())
                {
                    var user = await _context.Users.FindAsync(userId);
                    if (user == null)
                    {
                        return _responses.ResponseNotFound("لم يتم العثور على المستخدم.");
                    }
                    if (status == true)
                    {
                        #region Lock Account
                        user.IsLocked = true;
                        user.ModifierId = _tokenData.UserId();
                        user.ModifiedAt = DateTime.Now;
                        user.Token = null;
                        _context.Users.Update(user);
                        await _context.SaveChangesAsync();
                        #endregion
                        _responses.ResponseSuccess("تم تعطيل الحساب بنجاح");
                    }
                    else
                    {
                        #region Unlock Account 
                        user.IsLocked = false;
                        user.ModifierId = _tokenData.UserId();
                        user.ModifiedAt = DateTime.Now;
                        _context.Users.Update(user);
                        await _context.SaveChangesAsync();
                        #endregion
                        _responses.ResponseSuccess("تم اعادة تفعيل الحساب بنجاح");
                    }
                }
                return _responses.ResponseUnauthorized("لا تملك صلاحية الوصول الى البيانات .");


                throw new NotImplementedException();
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
        private bool VerifyPassword(string password, string storedHash)
        {
            var parts = storedHash.Split('.');
            var salt = Convert.FromBase64String(parts[0]);
            var hash = parts[1];

            var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hash == hashed;
        }
        private string GenerateToken(List<Claim> claims)
        {
            // Get the JWT server secret from configuration
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:ServerSecret"]!));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["JWT:Issuer"],
                _configuration["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(20),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}

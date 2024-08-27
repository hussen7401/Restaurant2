using Core.Dtos.Reservation;
using Core.Entities.Reservations;
using Core.Enums;
using Core.Helper;
using Core.Interface.Auth;
using Core.Interface.Reservation;
using Infrastructure.Data;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.Reservations
{
    public class TableService : ITableService
    {
        private readonly AppDbContext _context;
        private readonly Responses _responses;
        private readonly ITokenData _tokenData;

        public TableService(AppDbContext context,
                            Responses responses,
                            ITokenData tokenData)
        {
            _context = context;
            _responses = responses;
            _tokenData = tokenData;
        }
        public async Task<ActionResult> GetTables()
        {
            try
            {
                var tables = await _context.Tables.ToListAsync();

                if (tables == null)
                {
                    return _responses.ResponseNotFound("لا توجد طاولات متاحة!");
                }
                return _responses.ResponseSuccess("تم جلب الطاولات بنجاح.", tables);
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
        public async Task<ActionResult> GetTableById(int id)
        {
            try
            {
                var table = await _context.Tables.FindAsync(id);

                if (table == null)
                {
                    return _responses.ResponseNotFound("الطاولة المطلوبة غير متوفرة!");
                }

                return _responses.ResponseSuccess("تم جلب بيانات الطاولة بنجاح.", table);
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
        public async Task<ActionResult> CreateTable(TableDto tableDto)
        {
            if (await _tokenData.Role() == UserRoles.Customer.ToString())
            {
                return _responses.ResponseUnauthorized("لا تملك صلاحية لاضافة طاولة ");
            }
            else
            {
                try
                {
                    var existingTable = await _context.Tables.FirstOrDefaultAsync(t => t.TableNumber == tableDto.TableNumber);
                    if (existingTable != null)
                    {
                        return _responses.ResponseConflict("رقم الطاولة موجود بالفعل. يرجى اختيار رقم آخر.");
                    }
                    #region Add Table
                    var table = tableDto.Adapt<Table>();
                    table.CreateAt = DateTime.UtcNow;
                    table.CreatorId = _tokenData.UserId();
                    _context.Tables.Add(table);
                    await _context.SaveChangesAsync();
                    #endregion
                    return _responses.ResponseSuccess("تم إنشاء الطاولة بنجاح.",table);
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
        public async Task<ActionResult> UpdateTable(int id, TableDto tableDto)
        {
            if (await _tokenData.Role() == UserRoles.Customer.ToString())
            {
                return _responses.ResponseUnauthorized("لا تملك صلاحية لتغيير بيانات الطاولة .");
            }
            else
            {
                try
                {
                    var table = await _context.Tables.FindAsync(id);

                    if (table == null)
                    {
                        return _responses.ResponseNotFound("الطاولة المطلوبة غير متوفرة!");
                    }
                    else
                    {
                        var existingTable = await _context.Tables.FirstOrDefaultAsync(t => t.TableNumber == tableDto.TableNumber);
                        if (existingTable != null)
                        {
                            return _responses.ResponseConflict("رقم الطاولة موجود بالفعل. يرجى اختيار رقم آخر.");
                        }
                        #region Update Table
                        table.TableNumber = tableDto.TableNumber;
                        table.Capacity = tableDto.Capacity;
                        table.ModifierId = _tokenData.UserId();
                        table.ModifiedAt = DateTime.UtcNow;
                        _context.Tables.Update(table);
                        await _context.SaveChangesAsync();
                        #endregion
                        return _responses.ResponseSuccess("تم تحديث الطاولة بنجاح.", table);
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
        }
        public async Task<ActionResult> DeleteTable(int id)
        {
            if (await _tokenData.Role() == UserRoles.Customer.ToString())
            {
                return _responses.ResponseUnauthorized("لا تملك صلاحية لحذف الطاولة .");
            }
            else
            {
                try
                {
                    var table = await _context.Tables.FindAsync(id);

                    if (table == null)
                    {
                        return _responses.ResponseNotFound("الطاولة المطلوبة غير متوفرة!");
                    }
                    else
                    {
                        #region remove Table
                        _context.Tables.Remove(table);
                        await _context.SaveChangesAsync();
                        #endregion
                        return _responses.ResponseSuccess("تم حذف الطاولة بنجاح.", table);
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
        }
    }
}

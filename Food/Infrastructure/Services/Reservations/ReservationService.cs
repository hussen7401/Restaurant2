using Core.Dtos.Reservation;
using Core.Entities.Reservations;
using Core.Helper;
using Core.Interface.Auth;
using Core.Interface.Reservation;
using Infrastructure.Data;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.Reservations
{
    public class ReservationService : IReservationService
    {
        private readonly AppDbContext _context;
        private readonly Responses _responses;
        private readonly ITokenData _tokenData;
        public ReservationService(AppDbContext context, Responses responses, ITokenData tokenData)
        {
            _context = context;
            _responses = responses;
            _tokenData = tokenData;
        }
        public async Task<ActionResult> GetReservations()
        {
            try
            {
                var reservations = await _context.Reservations.Include(u => u.User).Include(t => t.Table).ToListAsync();
                if (reservations == null || !reservations.Any())
                {
                    return _responses.ResponseNotFound("لا توجد أي حجوزات !");
                }
                var ShowReservations = reservations.Adapt<List<ShowReservation>>();
                return _responses.ResponseSuccess("تم جلب الحجوزات بنجاح.", ShowReservations);
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
        public async Task<ActionResult> GetReservationById(int id)
        {
            try
            {
                var reservation = await _context.Reservations
                    .Include(u => u.User).Include(t => t.Table)
                    .FirstOrDefaultAsync(r => r.Id == id);

                if (reservation == null)
                {
                    return _responses.ResponseNotFound("الحجز المطلوب غير متوفر!");
                }

                var ShowReservation = reservation.Adapt<ShowReservation>();
                return _responses.ResponseSuccess("تم جلب بيانات الحجز بنجاح.", ShowReservation);
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
        public async Task<ActionResult> GetReservationsByUserId(int userId)
        {
            try
            {
                var reservations = await _context.Reservations
                  .Include(u => u.User).Include(t => t.Table)
                  .Where(r => r.UserId == userId)
                  .ToListAsync();


                if (reservations == null || !reservations.Any())
                {
                    return _responses.ResponseNotFound("لا توجد حجوزات لهذا المستخدم!");
                }
                var ShowReservations = reservations.Adapt<List<ShowReservation>>();
                return _responses.ResponseSuccess("تم جلب حجوزات المستخدم بنجاح.", ShowReservations);
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
        public async Task<ActionResult> CreateReservation(CreateReservation CreateR)
        {
            var openingTime = new TimeSpan(8, 0, 0);
            var closingTime = new TimeSpan(24, 0, 0);
            var reservationTime = CreateR.ReservationDate.TimeOfDay;

            if (reservationTime < openingTime || reservationTime >= closingTime)
            {
                return _responses.ResponseBadRequest("الوقت المحدد للحجز غير متاح. الرجاء اختيار وقت بين الساعة 8 صباحًا و12 مسائأ.");
            }
            var table = await _context.Tables.FindAsync(CreateR.TableId);

            if (table == null)
            {
                return _responses.ResponseNotFound("معرف الطاولة غير موجود.");
            }
            if (CreateR.NumberOfGuests > table.Capacity)
            {
                return _responses.ResponseConflict("عدد الضيوف اكثر من عدد المقاعد ");
            }
            try
            {
                var reserveTable = await _context.Reservations
                    .Where(r => r.TableId == CreateR.TableId &&
                    r.ReservationDate.Date == CreateR.ReservationDate.Date &&
                    r.ReservationDate.Hour == CreateR.ReservationDate.Hour)
                    .FirstOrDefaultAsync();

                if (reserveTable != null)
                {
                    return _responses.ResponseConflict("الطاولة محجوزة في هذا الوقت. الرجاء اختيار وقت آخر.");
                }

                #region Save Data 
                var reservation = CreateR.Adapt<Reservation>();
                reservation.UserId = Convert.ToInt32(_tokenData.UserId());
                reservation.CreateAt = DateTime.UtcNow;
                reservation.CreatorId = _tokenData.UserId();
                _context.Reservations.Add(reservation);
                await _context.SaveChangesAsync();
                #endregion
                return _responses.ResponseSuccess($"لقد قمت بحجز الطاولة بنجاح", reservation);
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
        public async Task<ActionResult> UpdateReservation(int id, UpdateReservation UpdateR)
        {
            try
            {
                var reservation = await _context.Reservations.Include(u => u.User).Include(t => t.Table).FirstAsync(r =>r.Id == id);
                if (_tokenData.UserId() != reservation!.UserId)
                {
                    return _responses.ResponseUnauthorized("لست مخول لتعديل هذا الحجز ");
                }
                if (reservation == null)
                {
                    return _responses.ResponseNotFound("الحجز المطلوب غير متوفر!");
                }

                #region Update Data 
                reservation.SpecialRequest = UpdateR.SpecialRequest;
                reservation.ReservationDate = UpdateR.ReservationDate;
                reservation.ModifiedAt = DateTime.UtcNow;
                reservation.ModifierId = _tokenData.UserId();

                _context.Reservations.Update(reservation);
                await _context.SaveChangesAsync();

                var ShowReservation = reservation.Adapt<ShowReservation>();
                #endregion
                return _responses.ResponseSuccess("تم تحديث الحجز بنجاح.", ShowReservation);
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
        public async Task<ActionResult> DeleteReservation(int id)
        {
            try
            {
                var reservation = await _context.Reservations.FindAsync(id);
                if (_tokenData.UserId() != reservation!.UserId)
                {
                    return _responses.ResponseUnauthorized("لست مخول لحذف هذا الحجز ");
                }
                if (reservation == null)
                {
                    return _responses.ResponseNotFound("الحجز المطلوب غير متوفر!");
                }

                if (DateTime.UtcNow - reservation.CreateAt > TimeSpan.FromHours(1))
                {
                    return _responses.ResponseBadRequest("لا يمكنك حذف الحجز بعد الان.");
                }
                _context.Reservations.Remove(reservation);
                await _context.SaveChangesAsync();

                return _responses.ResponseSuccess("تم حذف الحجز بنجاح.");
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

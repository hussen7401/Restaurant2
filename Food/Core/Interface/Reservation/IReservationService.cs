using Microsoft.AspNetCore.Mvc;
using Core.Dtos.Reservation;

namespace Core.Interface.Reservation
{
    public interface IReservationService
    {
        Task<ActionResult> GetReservations();
        Task<ActionResult> GetReservationsByUserId(int userId);
        Task<ActionResult> GetReservationById(int id);
        Task<ActionResult> CreateReservation(CreateReservation CreateR);
        Task<ActionResult> UpdateReservation(int id, UpdateReservation UpdateR);
        Task<ActionResult> DeleteReservation(int id);
    }
}

using Core.Dtos.Reservation;
using Core.Interface.Reservation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Reservation
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet]
        public async Task<ActionResult> GetReservations()
        {
            return await _reservationService.GetReservations();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetReservation(int id)
        {
            return await _reservationService.GetReservationById(id);
        }

        [HttpGet("User/{userId}")]
        public async Task<ActionResult> GetReservationsByUserId(int userId)
        {
            return await _reservationService.GetReservationsByUserId(userId);
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateReservation([FromBody] CreateReservation CreateR)
        {
            return await _reservationService.CreateReservation(CreateR);
        }

        [HttpPut("Update/{id}")]
        public async Task<ActionResult> UpdateReservation(int id, [FromBody] UpdateReservation UpdateR)
        {
            return await _reservationService.UpdateReservation(id, UpdateR);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteReservation(int id)
        {
            return await _reservationService.DeleteReservation(id);
        }
    }
}

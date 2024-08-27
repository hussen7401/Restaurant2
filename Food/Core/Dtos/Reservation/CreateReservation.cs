using System.ComponentModel.DataAnnotations;

namespace Core.Dtos.Reservation
{
    public class CreateReservation
    {
        public required int TableId { get; set; }
        public required DateTime ReservationDate { get; set; }
        [Range(1,20)]
        public required int NumberOfGuests { get; set; }
        public string? SpecialRequest { get; set; }
    }
}

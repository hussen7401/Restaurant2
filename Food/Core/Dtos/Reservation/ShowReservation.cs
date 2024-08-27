using Core.Dtos.User;

namespace Core.Dtos.Reservation
{
    public class ShowReservation
    {
        public int Id { get; set; }
        public int NumberOfGuests { get; set; }
        public DateTime ReservationDate { get; set; }
        public UserInfo? User { get; set; }
        public ShowTable? Table { get; set; }
        public string? SpecialRequest { get; set; }
        public DateTime CreateAt { get; set; }
        public int? ModifierId { get; set; }
        public DateTime? ModifiedAt { get; set; }

    }
}

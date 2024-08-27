using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Reservations
{
    public class Reservation : EntityBase
    {
        public int UserId { get; set; }
        public int TableId { get; set; }
        public DateTime ReservationDate { get; set; }
        public int NumberOfGuests { get; set; }
        public string? SpecialRequest { get; set; }


        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }

        [ForeignKey(nameof(TableId))]
        public Table? Table { get; set; }
    }
}

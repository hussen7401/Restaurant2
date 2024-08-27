
namespace Core.Entities
{
    public class EntityBase
    {
        public int Id { get; set; }
        public int? CreatorId { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        public int? ModifierId { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}


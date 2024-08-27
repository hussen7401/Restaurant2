namespace Core.Entities
{
    public class MenuItem : EntityBase
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; } 
    }
}

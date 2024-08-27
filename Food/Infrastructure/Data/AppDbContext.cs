using Core.Entities.Reservations;
using Core.Entities;
using Core.Enums;
using Infrastructure.Security;
using Microsoft.EntityFrameworkCore;
using Core.Entities.Orders;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var Security = new SecurityHelper();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FullName = "hussen fadhel",
                    UserName = "SuperAdmin",
                    Email = "SuperAdmin@gmail.com",
                    PasswordHash = Security.HashPassword("SuperAdmin"),
                    Role = UserRoles.SuperAdmin
                }
            );
            modelBuilder.Entity<Table>().HasData(
                 new Table { Id = 1, CreatorId = 1, TableNumber = 1, Capacity = 2, },
                 new Table { Id = 2, CreatorId = 1, TableNumber = 2, Capacity = 2, },
                 new Table { Id = 3, CreatorId = 1, TableNumber = 3, Capacity = 2, },
                 new Table { Id = 4, CreatorId = 1, TableNumber = 4, Capacity = 4, },
                 new Table { Id = 5, CreatorId = 1, TableNumber = 5, Capacity = 4, },
                 new Table { Id = 6, CreatorId = 1, TableNumber = 6, Capacity = 4, },
                 new Table { Id = 7, CreatorId = 1, TableNumber = 7, Capacity = 6, },
                 new Table { Id = 8, CreatorId = 1, TableNumber = 8, Capacity = 6, },
                 new Table { Id = 9, CreatorId = 1, TableNumber = 9, Capacity = 6, },
                 new Table { Id = 10, CreatorId = 1, TableNumber = 10, Capacity = 10, },
                 new Table { Id = 11, CreatorId = 1, TableNumber = 11, Capacity = 10, },
                 new Table { Id = 12, CreatorId = 1, TableNumber = 12, Capacity = 20, }
            );
            modelBuilder.Entity<MenuItem>().HasData(
                new MenuItem { Id = 1, Name = "Classic Burger", Description = "A delicious beef burger with lettuce, tomato, and cheese.", Price = 10.99m, CreatorId = 1, IsAvailable = true },
                new MenuItem { Id = 2, Name = "Veggie Pizza", Description = "A pizza topped with fresh vegetables and mozzarella cheese.", Price = 12.50m, CreatorId = 1, IsAvailable = true },
                new MenuItem { Id = 3, Name = "Caesar Salad", Description = "Crisp romaine lettuce with Caesar dressing and croutons.", Price = 8.25m, CreatorId = 1, IsAvailable = true },
                new MenuItem { Id = 4, Name = "Spaghetti Bolognese", Description = "Spaghetti pasta served with a rich meat sauce.", Price = 14.75m, CreatorId = 1, IsAvailable = true },
                new MenuItem { Id = 5, Name = "Grilled Salmon", Description = "Grilled salmon fillet served with a side of vegetables.", Price = 18.50m, CreatorId = 1, IsAvailable = true }
            );
        }
    }
}

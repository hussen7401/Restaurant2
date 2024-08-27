using Core.Dtos.Reservation;
using Core.Dtos.User;
using Core.Entities.Reservations;
using Core.Entities;
using Core.Enums;
using Mapster;
using Core.Dtos;
using Core.Entities.Orders;
using Core.Dtos.Orders;

namespace Core.Mapster
{
    public class MappingConfig 
    {
        public static void ConfigureMappings()
        {
            // User Register - AuthServise
            TypeAdapterConfig<Register, User>.NewConfig()
                .Map(dest => dest.FullName, src => $"{src.FirstName} {src.LastName}")
                .Map(dest => dest.Role, src => UserRoles.Customer)
                .Ignore(dest => dest.PasswordHash!);

            // User ShowUserToAdmin 
            TypeAdapterConfig<User, ShowUserToAdmin>.NewConfig()
                .Map(dest => dest.Role, src => Enum.GetName(src.Role));

            // Update User 
            TypeAdapterConfig<UpdateUser, User>.NewConfig()
                .Map(dest => dest.FullName, src => $"{src.FirstName} {src.LastName}");

            // User ShowUser 
            TypeAdapterConfig<User, ShowUser>.NewConfig();

            // CreateTable - TableServise
            TypeAdapterConfig<TableDto, Table>.NewConfig();

            // Reservation - ReservationServise
            TypeAdapterConfig<Reservation, ShowReservation>.NewConfig();

            // CreateReservation 
            TypeAdapterConfig<CreateReservation, Reservation>.NewConfig();

            // MenuItem - MenuItemServise
            TypeAdapterConfig<MenuItemDto, MenuItem>.NewConfig();

            // Order -OrderServise
            TypeAdapterConfig<Order, ShowOrder>.NewConfig();
            TypeAdapterConfig<OrderItemDto, OrderItem>.NewConfig();
        }
    }
}

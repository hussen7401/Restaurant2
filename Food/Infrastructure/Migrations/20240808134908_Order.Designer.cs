﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240808134908_Order")]
    partial class Order
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Core.Entities.MenuItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("CreatorId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("ModifierId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("MenuItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateAt = new DateTime(2024, 8, 8, 13, 49, 7, 593, DateTimeKind.Utc).AddTicks(7277),
                            CreatorId = 1,
                            Description = "A delicious beef burger with lettuce, tomato, and cheese.",
                            IsAvailable = true,
                            Name = "Classic Burger",
                            Price = 10.99m
                        },
                        new
                        {
                            Id = 2,
                            CreateAt = new DateTime(2024, 8, 8, 13, 49, 7, 593, DateTimeKind.Utc).AddTicks(7285),
                            CreatorId = 1,
                            Description = "A pizza topped with fresh vegetables and mozzarella cheese.",
                            IsAvailable = true,
                            Name = "Veggie Pizza",
                            Price = 12.50m
                        },
                        new
                        {
                            Id = 3,
                            CreateAt = new DateTime(2024, 8, 8, 13, 49, 7, 593, DateTimeKind.Utc).AddTicks(7288),
                            CreatorId = 1,
                            Description = "Crisp romaine lettuce with Caesar dressing and croutons.",
                            IsAvailable = true,
                            Name = "Caesar Salad",
                            Price = 8.25m
                        },
                        new
                        {
                            Id = 4,
                            CreateAt = new DateTime(2024, 8, 8, 13, 49, 7, 593, DateTimeKind.Utc).AddTicks(7291),
                            CreatorId = 1,
                            Description = "Spaghetti pasta served with a rich meat sauce.",
                            IsAvailable = true,
                            Name = "Spaghetti Bolognese",
                            Price = 14.75m
                        },
                        new
                        {
                            Id = 5,
                            CreateAt = new DateTime(2024, 8, 8, 13, 49, 7, 593, DateTimeKind.Utc).AddTicks(7293),
                            CreatorId = 1,
                            Description = "Grilled salmon fillet served with a side of vegetables.",
                            IsAvailable = true,
                            Name = "Grilled Salmon",
                            Price = 18.50m
                        });
                });

            modelBuilder.Entity("Core.Entities.Orders.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("CreatorId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("ModifierId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("numeric");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Core.Entities.Orders.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("CreatorId")
                        .HasColumnType("integer");

                    b.Property<int>("MenuItemId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("ModifierId")
                        .HasColumnType("integer");

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("MenuItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("Core.Entities.Reservations.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("CreatorId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("ModifierId")
                        .HasColumnType("integer");

                    b.Property<int>("NumberOfGuests")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("SpecialRequest")
                        .HasColumnType("text");

                    b.Property<int>("TableId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TableId");

                    b.HasIndex("UserId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("Core.Entities.Reservations.Table", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Capacity")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("CreatorId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("ModifierId")
                        .HasColumnType("integer");

                    b.Property<int>("TableNumber")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Tables");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Capacity = 2,
                            CreateAt = new DateTime(2024, 8, 8, 13, 49, 7, 593, DateTimeKind.Utc).AddTicks(7023),
                            CreatorId = 1,
                            TableNumber = 1
                        },
                        new
                        {
                            Id = 2,
                            Capacity = 2,
                            CreateAt = new DateTime(2024, 8, 8, 13, 49, 7, 593, DateTimeKind.Utc).AddTicks(7031),
                            CreatorId = 1,
                            TableNumber = 2
                        },
                        new
                        {
                            Id = 3,
                            Capacity = 2,
                            CreateAt = new DateTime(2024, 8, 8, 13, 49, 7, 593, DateTimeKind.Utc).AddTicks(7034),
                            CreatorId = 1,
                            TableNumber = 3
                        },
                        new
                        {
                            Id = 4,
                            Capacity = 4,
                            CreateAt = new DateTime(2024, 8, 8, 13, 49, 7, 593, DateTimeKind.Utc).AddTicks(7036),
                            CreatorId = 1,
                            TableNumber = 4
                        },
                        new
                        {
                            Id = 5,
                            Capacity = 4,
                            CreateAt = new DateTime(2024, 8, 8, 13, 49, 7, 593, DateTimeKind.Utc).AddTicks(7176),
                            CreatorId = 1,
                            TableNumber = 5
                        },
                        new
                        {
                            Id = 6,
                            Capacity = 4,
                            CreateAt = new DateTime(2024, 8, 8, 13, 49, 7, 593, DateTimeKind.Utc).AddTicks(7178),
                            CreatorId = 1,
                            TableNumber = 6
                        },
                        new
                        {
                            Id = 7,
                            Capacity = 6,
                            CreateAt = new DateTime(2024, 8, 8, 13, 49, 7, 593, DateTimeKind.Utc).AddTicks(7180),
                            CreatorId = 1,
                            TableNumber = 7
                        },
                        new
                        {
                            Id = 8,
                            Capacity = 6,
                            CreateAt = new DateTime(2024, 8, 8, 13, 49, 7, 593, DateTimeKind.Utc).AddTicks(7182),
                            CreatorId = 1,
                            TableNumber = 8
                        },
                        new
                        {
                            Id = 9,
                            Capacity = 6,
                            CreateAt = new DateTime(2024, 8, 8, 13, 49, 7, 593, DateTimeKind.Utc).AddTicks(7183),
                            CreatorId = 1,
                            TableNumber = 9
                        },
                        new
                        {
                            Id = 10,
                            Capacity = 10,
                            CreateAt = new DateTime(2024, 8, 8, 13, 49, 7, 593, DateTimeKind.Utc).AddTicks(7185),
                            CreatorId = 1,
                            TableNumber = 10
                        },
                        new
                        {
                            Id = 11,
                            Capacity = 10,
                            CreateAt = new DateTime(2024, 8, 8, 13, 49, 7, 593, DateTimeKind.Utc).AddTicks(7187),
                            CreatorId = 1,
                            TableNumber = 11
                        },
                        new
                        {
                            Id = 12,
                            Capacity = 20,
                            CreateAt = new DateTime(2024, 8, 8, 13, 49, 7, 593, DateTimeKind.Utc).AddTicks(7190),
                            CreatorId = 1,
                            TableNumber = 12
                        });
                });

            modelBuilder.Entity("Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("CreatorId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("DeleterId")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsLocked")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastLoginDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("LockTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("ModifierId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("OtpExpire")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("OtpToken")
                        .HasColumnType("integer");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<string>("Token")
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessFailedCount = 0,
                            CreateAt = new DateTime(2024, 8, 8, 13, 49, 7, 578, DateTimeKind.Utc).AddTicks(4862),
                            Email = "SuperAdmin@gmail.com",
                            FullName = "hussen fadhel",
                            IsDeleted = false,
                            IsLocked = false,
                            PasswordHash = "vyIrydG2ltwrvc9b5mmVbA==.0xjA2dSbqSxetq+HkchDJk0Ox5H193VYGK1XXIFCA7w=",
                            Role = 0,
                            UserName = "SuperAdmin"
                        });
                });

            modelBuilder.Entity("Core.Entities.Orders.Order", b =>
                {
                    b.HasOne("Core.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Entities.Orders.OrderItem", b =>
                {
                    b.HasOne("Core.Entities.MenuItem", "MenuItem")
                        .WithMany()
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Orders.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MenuItem");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Core.Entities.Reservations.Reservation", b =>
                {
                    b.HasOne("Core.Entities.Reservations.Table", "Table")
                        .WithMany()
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Table");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Entities.Orders.Order", b =>
                {
                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}

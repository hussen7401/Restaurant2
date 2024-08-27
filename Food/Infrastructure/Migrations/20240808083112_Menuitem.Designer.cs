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
    [Migration("20240808083112_Menuitem")]
    partial class Menuitem
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

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("MenuItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateAt = new DateTime(2024, 8, 8, 8, 31, 12, 212, DateTimeKind.Utc).AddTicks(3890),
                            CreatorId = 1,
                            Description = "A delicious beef burger with lettuce, tomato, and cheese.",
                            IsAvailable = true,
                            Name = "Classic Burger",
                            Price = 10.99
                        },
                        new
                        {
                            Id = 2,
                            CreateAt = new DateTime(2024, 8, 8, 8, 31, 12, 212, DateTimeKind.Utc).AddTicks(3895),
                            CreatorId = 1,
                            Description = "A pizza topped with fresh vegetables and mozzarella cheese.",
                            IsAvailable = true,
                            Name = "Veggie Pizza",
                            Price = 12.5
                        },
                        new
                        {
                            Id = 3,
                            CreateAt = new DateTime(2024, 8, 8, 8, 31, 12, 212, DateTimeKind.Utc).AddTicks(3898),
                            CreatorId = 1,
                            Description = "Crisp romaine lettuce with Caesar dressing and croutons.",
                            IsAvailable = true,
                            Name = "Caesar Salad",
                            Price = 8.25
                        },
                        new
                        {
                            Id = 4,
                            CreateAt = new DateTime(2024, 8, 8, 8, 31, 12, 212, DateTimeKind.Utc).AddTicks(3900),
                            CreatorId = 1,
                            Description = "Spaghetti pasta served with a rich meat sauce.",
                            IsAvailable = true,
                            Name = "Spaghetti Bolognese",
                            Price = 14.75
                        },
                        new
                        {
                            Id = 5,
                            CreateAt = new DateTime(2024, 8, 8, 8, 31, 12, 212, DateTimeKind.Utc).AddTicks(3904),
                            CreatorId = 1,
                            Description = "Grilled salmon fillet served with a side of vegetables.",
                            IsAvailable = true,
                            Name = "Grilled Salmon",
                            Price = 18.5
                        });
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
                            CreateAt = new DateTime(2024, 8, 8, 8, 31, 12, 212, DateTimeKind.Utc).AddTicks(3752),
                            CreatorId = 1,
                            TableNumber = 1
                        },
                        new
                        {
                            Id = 2,
                            Capacity = 2,
                            CreateAt = new DateTime(2024, 8, 8, 8, 31, 12, 212, DateTimeKind.Utc).AddTicks(3761),
                            CreatorId = 1,
                            TableNumber = 2
                        },
                        new
                        {
                            Id = 3,
                            Capacity = 2,
                            CreateAt = new DateTime(2024, 8, 8, 8, 31, 12, 212, DateTimeKind.Utc).AddTicks(3766),
                            CreatorId = 1,
                            TableNumber = 3
                        },
                        new
                        {
                            Id = 4,
                            Capacity = 4,
                            CreateAt = new DateTime(2024, 8, 8, 8, 31, 12, 212, DateTimeKind.Utc).AddTicks(3768),
                            CreatorId = 1,
                            TableNumber = 4
                        },
                        new
                        {
                            Id = 5,
                            Capacity = 4,
                            CreateAt = new DateTime(2024, 8, 8, 8, 31, 12, 212, DateTimeKind.Utc).AddTicks(3770),
                            CreatorId = 1,
                            TableNumber = 5
                        },
                        new
                        {
                            Id = 6,
                            Capacity = 4,
                            CreateAt = new DateTime(2024, 8, 8, 8, 31, 12, 212, DateTimeKind.Utc).AddTicks(3771),
                            CreatorId = 1,
                            TableNumber = 6
                        },
                        new
                        {
                            Id = 7,
                            Capacity = 6,
                            CreateAt = new DateTime(2024, 8, 8, 8, 31, 12, 212, DateTimeKind.Utc).AddTicks(3774),
                            CreatorId = 1,
                            TableNumber = 7
                        },
                        new
                        {
                            Id = 8,
                            Capacity = 6,
                            CreateAt = new DateTime(2024, 8, 8, 8, 31, 12, 212, DateTimeKind.Utc).AddTicks(3778),
                            CreatorId = 1,
                            TableNumber = 8
                        },
                        new
                        {
                            Id = 9,
                            Capacity = 6,
                            CreateAt = new DateTime(2024, 8, 8, 8, 31, 12, 212, DateTimeKind.Utc).AddTicks(3782),
                            CreatorId = 1,
                            TableNumber = 9
                        },
                        new
                        {
                            Id = 10,
                            Capacity = 10,
                            CreateAt = new DateTime(2024, 8, 8, 8, 31, 12, 212, DateTimeKind.Utc).AddTicks(3784),
                            CreatorId = 1,
                            TableNumber = 10
                        },
                        new
                        {
                            Id = 11,
                            Capacity = 10,
                            CreateAt = new DateTime(2024, 8, 8, 8, 31, 12, 212, DateTimeKind.Utc).AddTicks(3785),
                            CreatorId = 1,
                            TableNumber = 11
                        },
                        new
                        {
                            Id = 12,
                            Capacity = 20,
                            CreateAt = new DateTime(2024, 8, 8, 8, 31, 12, 212, DateTimeKind.Utc).AddTicks(3787),
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
                            CreateAt = new DateTime(2024, 8, 8, 8, 31, 12, 196, DateTimeKind.Utc).AddTicks(7154),
                            Email = "SuperAdmin@gmail.com",
                            FullName = "hussen fadhel",
                            IsDeleted = false,
                            IsLocked = false,
                            PasswordHash = "QctaoHIa4yr+VpQaactjvw==.USQWZw1/cGB6kJPL8U5n6ZiMnEzNvKKMsdsAC6OXxiQ=",
                            Role = 0,
                            UserName = "SuperAdmin"
                        });
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
#pragma warning restore 612, 618
        }
    }
}

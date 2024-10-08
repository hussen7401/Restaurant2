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
    [Migration("20240807143720_tables")]
    partial class tables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Core.Entities.Reservation.Table", b =>
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
                            CreateAt = new DateTime(2024, 8, 7, 14, 37, 19, 384, DateTimeKind.Utc).AddTicks(3082),
                            CreatorId = 1,
                            TableNumber = 1
                        },
                        new
                        {
                            Id = 2,
                            Capacity = 2,
                            CreateAt = new DateTime(2024, 8, 7, 14, 37, 19, 384, DateTimeKind.Utc).AddTicks(3091),
                            CreatorId = 1,
                            TableNumber = 2
                        },
                        new
                        {
                            Id = 3,
                            Capacity = 2,
                            CreateAt = new DateTime(2024, 8, 7, 14, 37, 19, 384, DateTimeKind.Utc).AddTicks(3092),
                            CreatorId = 1,
                            TableNumber = 3
                        },
                        new
                        {
                            Id = 4,
                            Capacity = 4,
                            CreateAt = new DateTime(2024, 8, 7, 14, 37, 19, 384, DateTimeKind.Utc).AddTicks(3094),
                            CreatorId = 1,
                            TableNumber = 4
                        },
                        new
                        {
                            Id = 5,
                            Capacity = 4,
                            CreateAt = new DateTime(2024, 8, 7, 14, 37, 19, 384, DateTimeKind.Utc).AddTicks(3095),
                            CreatorId = 1,
                            TableNumber = 5
                        },
                        new
                        {
                            Id = 6,
                            Capacity = 4,
                            CreateAt = new DateTime(2024, 8, 7, 14, 37, 19, 384, DateTimeKind.Utc).AddTicks(3097),
                            CreatorId = 1,
                            TableNumber = 6
                        },
                        new
                        {
                            Id = 7,
                            Capacity = 6,
                            CreateAt = new DateTime(2024, 8, 7, 14, 37, 19, 384, DateTimeKind.Utc).AddTicks(3098),
                            CreatorId = 1,
                            TableNumber = 7
                        },
                        new
                        {
                            Id = 8,
                            Capacity = 6,
                            CreateAt = new DateTime(2024, 8, 7, 14, 37, 19, 384, DateTimeKind.Utc).AddTicks(3100),
                            CreatorId = 1,
                            TableNumber = 8
                        },
                        new
                        {
                            Id = 9,
                            Capacity = 6,
                            CreateAt = new DateTime(2024, 8, 7, 14, 37, 19, 384, DateTimeKind.Utc).AddTicks(3101),
                            CreatorId = 1,
                            TableNumber = 9
                        },
                        new
                        {
                            Id = 10,
                            Capacity = 10,
                            CreateAt = new DateTime(2024, 8, 7, 14, 37, 19, 384, DateTimeKind.Utc).AddTicks(3103),
                            CreatorId = 1,
                            TableNumber = 10
                        },
                        new
                        {
                            Id = 11,
                            Capacity = 10,
                            CreateAt = new DateTime(2024, 8, 7, 14, 37, 19, 384, DateTimeKind.Utc).AddTicks(3104),
                            CreatorId = 1,
                            TableNumber = 11
                        },
                        new
                        {
                            Id = 12,
                            Capacity = 20,
                            CreateAt = new DateTime(2024, 8, 7, 14, 37, 19, 384, DateTimeKind.Utc).AddTicks(3105),
                            CreatorId = 1,
                            TableNumber = 12
                        });
                });

            modelBuilder.Entity("Core.Entities.User.User", b =>
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
                            CreateAt = new DateTime(2024, 8, 7, 14, 37, 19, 371, DateTimeKind.Utc).AddTicks(4427),
                            Email = "SuperAdmin@gmail.com",
                            FullName = "hussen fadhel",
                            IsDeleted = false,
                            IsLocked = false,
                            PasswordHash = "YAGtOMLg/HlYu6YDDnIlxA==.QAAR+7m6h2t/8wJv2jRNh56bAgcpoD1RyYSZijLCYKI=",
                            Role = 0,
                            UserName = "SuperAdmin"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

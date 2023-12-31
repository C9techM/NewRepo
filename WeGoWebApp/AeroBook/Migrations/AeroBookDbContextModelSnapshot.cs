﻿// <auto-generated />
using System;
using AeroBook.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AeroBook.Migrations
{
    [DbContext(typeof(AeroBookDbContext))]
    partial class AeroBookDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AeroBook.Data.Models.Account.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AeroBook.Data.Models.Flights.BookingDetails", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingId"));

                    b.Property<int>("FlightId")
                        .HasColumnType("int");

                    b.Property<int>("FlightdetailsFlightId")
                        .HasColumnType("int");

                    b.Property<int>("PaymentMode")
                        .HasColumnType("int");

                    b.Property<int>("TotalPay")
                        .HasColumnType("int");

                    b.Property<int>("noOfPersons")
                        .HasColumnType("int");

                    b.Property<int>("paymentStatus")
                        .HasColumnType("int");

                    b.HasKey("BookingId");

                    b.HasIndex("FlightdetailsFlightId");

                    b.ToTable("BookingDetails");
                });

            modelBuilder.Entity("AeroBook.Data.Models.Flights.Flightdetails", b =>
                {
                    b.Property<int>("FlightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FlightId"));

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Availability")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FlightName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FromLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PricePerPerson")
                        .HasColumnType("int");

                    b.Property<string>("ToLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FlightId");

                    b.ToTable("Flightdetails");
                });

            modelBuilder.Entity("AeroBook.Data.Models.Flights.PassengerDetails", b =>
                {
                    b.Property<int>("PassengerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PassengerId"));

                    b.Property<string>("AadharId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("BookingDetailsBookingId")
                        .HasColumnType("int");

                    b.Property<int>("BookingId")
                        .HasColumnType("int");

                    b.Property<string>("PassengerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PassengerId");

                    b.HasIndex("BookingDetailsBookingId");

                    b.ToTable("PassengerDetails");
                });

            modelBuilder.Entity("AeroBook.Data.Models.Flights.BookingDetails", b =>
                {
                    b.HasOne("AeroBook.Data.Models.Flights.Flightdetails", "Flightdetails")
                        .WithMany()
                        .HasForeignKey("FlightdetailsFlightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Flightdetails");
                });

            modelBuilder.Entity("AeroBook.Data.Models.Flights.PassengerDetails", b =>
                {
                    b.HasOne("AeroBook.Data.Models.Flights.BookingDetails", "BookingDetails")
                        .WithMany()
                        .HasForeignKey("BookingDetailsBookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookingDetails");
                });
#pragma warning restore 612, 618
        }
    }
}

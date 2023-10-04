using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hotel.Models;

namespace Hotel.Data
{
    public class HotelContext : DbContext
    {
        public HotelContext (DbContextOptions<HotelContext> options)
            : base(options)
        {
        }

        public DbSet<Hotel.Models.Booking> Booking { get; set; } = default!;

        public DbSet<Hotel.Models.BusinessService> BusinessService { get; set; } = default!;

        public DbSet<Hotel.Models.CheckIn> CheckIn { get; set; } = default!;

        public DbSet<Hotel.Models.Consumption> Consumption { get; set; } = default!;

        public DbSet<Hotel.Models.Department> Department { get; set; } = default!;

        public DbSet<Hotel.Models.Guest> Guest { get; set; } = default!;

        public DbSet<Hotel.Models.Member> Member { get; set; } = default!;

        public DbSet<Hotel.Models.Payment> Payment { get; set; } = default!;

        public DbSet<Hotel.Models.Room> Room { get; set; } = default!;

        public DbSet<Hotel.Models.RoomService> RoomService { get; set; } = default!;

        public DbSet<Hotel.Models.Staff> Staff { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>().HasData(
                new Booking
                {
                    bookID = 1,
                    ReferenceNumber = "IN20220123001",
                    MemID = 1,
                    room_Type1 = "Single",
                    room_Quantity1 = 1,
                    room_Type2 = "Two Bedrooms",
                    room_Quantity2 = 2,
                    room_Type3 = "null",
                    room_Quantity3 = 0,
                    CheckInTime = new DateTime(2022 - 01 - 23),
                    CheckOutTime = new DateTime(2022 - 01 - 30),
                    CarPark = 2,
                },
                new Booking
                {
                    bookID = 2,
                    ReferenceNumber = "IN20231004005",
                    MemID = 2,
                    room_Type1 = "Two Bedrooms",
                    room_Quantity1 = 1,
                    room_Type2 = "null",
                    room_Quantity2 = 0,
                    room_Type3 = "null",
                    room_Quantity3 = 0,
                    CheckInTime = new DateTime(2023 - 10 - 4),
                    CheckOutTime = new DateTime(2023 - 10 - 8),
                    CarPark = 1,
                }
                );

            modelBuilder.Entity<BusinessService>()
                .Property(e => e.BS_Price)
                .HasPrecision(5, 2);
            modelBuilder.Entity<BusinessService>()
                .Property(e => e.BS_Rate)
                .HasPrecision(3, 2);
            modelBuilder.Entity<BusinessService>().HasData(
                new BusinessService
                {
                    BS_ID = 1,
                    BS_Name = "Customized Breakfast",
                    BS_Price = new decimal(20.00),
                    BS_Rate = new decimal(1.0),
                    BS_Description = "Guests can order and deliver meals to their rooms.",
                },
                new BusinessService
                {
                    BS_ID = 2,
                    BS_Name = "Dry-clean Services",
                    BS_Price = new decimal(20.00),
                    BS_Rate = new decimal(1.0),
                    BS_Description = "Dry clean clothes for guests, iron them and deliver them to guest rooms.",
                }
                );

            modelBuilder.Entity<CheckIn>()
                .Property(e => e.pre_payment_amount)
                .HasPrecision(5, 2);
            modelBuilder.Entity<CheckIn>().HasData(
                new CheckIn
                {
                    CheckId = 1,
                    guestID = 1,
                    roomID = 2,
                    CheckInDate = new DateTime(10 / 5 / 2022),
                    CheckOutDate = new DateTime(15 / 5 / 2022),
                    pre_payment_amount = new decimal(150.00),
                    pre_payment_method = "Credit Card",
                },
                new CheckIn
                {
                    CheckId = 2,
                    guestID = 2,
                    roomID = 1,
                    CheckInDate = new DateTime(30 / 9 / 2023),
                    CheckOutDate = new DateTime(),
                    pre_payment_amount = new decimal(150.00),
                    pre_payment_method = "Credit Card",
                }
                );

            modelBuilder.Entity<Consumption>()
                .Property(e => e.con_Amount)
                .HasPrecision(6, 2);
            modelBuilder.Entity<Consumption>().HasData(
                new Consumption
                {
                    con_ID = 1,
                    guestID = 1,
                    BS_ID = 1,
                    Service_Quantity = 2,
                    con_Amount = new decimal(40.00),
                },
                new Consumption
                {
                    con_ID = 2,
                    guestID = 2,
                    BS_ID = 2,
                    Service_Quantity = 1,
                    con_Amount = new decimal(50.00),
                }
                );

            modelBuilder.Entity<Department>().HasData(
                new Department
                {
                    de_ID = 1,
                    de_Name = "Customer Service Department",
                },
                new Department
                {
                    de_ID = 2,
                    de_Name = "IT Department",
                },
                new Department
                {
                    de_ID = 3,
                    de_Name = "Engineering Department"
                }
                );

            modelBuilder.Entity<Guest>().HasData(
                new Guest
                {
                    GuestID = 1,
                    FName = "Quentin",
                    LName = "Jim",
                    ID = "025467895",
                    Gender = "Male",
                    Phone = "02146578",
                    Email = "quentin@guest.com",
                    Hometown = "Christchurch",
                    Preference = "Adventure",
                    Organization = "Individual",
                },
                new Guest
                {
                    GuestID = 2,
                    FName = "Alison",
                    LName = "Jim",
                    ID = "025467858",
                    Gender = "Female",
                    Phone = "0256487",
                    Email = "alison@guest.com",
                    Hometown = "Queenstown",
                    Preference = "Music",
                    Organization = "SIT",
                }
                );

            modelBuilder.Entity<Member>().HasData(
                new Member
                {
                    MemID = 1,
                    FName = "Alfred",
                    LName = "Ben",
                    Organization = "Individual",
                    Gender = "Male",
                    Category = "Bronze",
                    Email = "alfred@member.com",
                    Password = "Alfred12345",
                    Phone = "0236547",
                    Address = "150 Eye Street, Invercargill",
                },
                new Member
                {
                    MemID = 2,
                    FName = "Aditi",
                    LName = "Agatha",
                    Organization = "SIT",
                    Gender = "Female",
                    Category = "Gold",
                    Email = "aditi@member.com",
                    Password = "Aditi12345",
                    Phone = "0236556",
                    Address = "1260 Eye Street, Christchurch",
                }
                );

            modelBuilder.Entity<Payment>()
                .Property(e => e.payment_Rate)
                .HasPrecision(3, 2);
            modelBuilder.Entity<Payment>()
                .Property(e => e.payment_Amount)
                .HasPrecision(6, 2);
            modelBuilder.Entity<Payment>()
                .Property(e=>e.Consumption_Charges)
                .HasPrecision(5, 2);
            modelBuilder.Entity<Payment>().HasData(
                new Payment
                {
                    payment_ID = 1,
                    guestID = 1,
                    Accommodation_days=5,
                    Consumption_Charges=new decimal(45.00),
                    create_date = new DateTime(10 / 5 / 2022),
                    payment_Rate = new decimal(1.0),
                    payment_Amount = new decimal(250.00),
                    pay_method = "Cash",
                    paid_date = new DateTime(15 / 5 / 2022),
                },
                new Payment
                {
                    payment_ID = 2,
                    guestID = 2,
                    Accommodation_days=0,
                    Consumption_Charges=new decimal(0.00),
                    create_date = new DateTime(30 / 9 / 2023),
                    payment_Rate = new decimal(1.0),
                    payment_Amount = new decimal(0.00),
                    pay_method = "Pending",
                    paid_date = new DateTime(),
                }
             );

            modelBuilder.Entity<Room>()
                .Property(e => e.room_Rate)
                .HasPrecision(3, 2);
            modelBuilder.Entity<Room>()
                .Property(e => e.room_Price)
                .HasPrecision(5, 2);
            modelBuilder.Entity<Room>().HasData(
                new Room
                {
                    room_ID = 1,
                    room_Name = "Sunshine King",
                    room_Type = "Single",
                    room_number = "C-23",
                    room_Price = new decimal(168.00),
                    room_Rate = new decimal(1),
                    room_Description = "Sleeps 2,Free WiFi,Free self parking,36 sq m,1 King Bed",
                    room_Status = "Avacant Clean",
                },
                new Room
                {
                    room_ID = 2,
                    room_Name = "Sunshine Twin",
                    room_Type = "Two Bedrooms",
                    room_number = "B-32",
                    room_Price = new decimal(185.00),
                    room_Rate = new decimal(1),
                    room_Description = "Sleeps 2,Free WiFi,Free self parking,60 sq m,1 Twin Bed",
                    room_Status = "Occupied Clean",
                }
                );

            modelBuilder.Entity<RoomService>().HasData(
                new RoomService
                {
                    ServiceId = 1,
                    Type = "Clear",
                    staffID = 1,
                    RoomID = 1,
                    Status = "Execeting",
                },
                new RoomService
                {
                    ServiceId = 2,
                    Type = "Maintenance",
                    staffID = 1,
                    RoomID = 1,
                    Status = "Execeting",
                }
                );

            modelBuilder.Entity<Staff>().HasData(
                new Staff
                {
                    staff_ID = 1,
                    staff_FName = "Ben",
                    staff_LName = "Cary",
                    staff_Gender = "Male",
                    de_ID = 3,
                    staff_Position = "Manager",
                    staff_Email = "ben@kousekeeper.com",
                    staff_Password = "Ben12345",
                    staff_Phone = "02156941",
                    staff_Address = "120 Wilfrid Street",
                },
                new Staff
                {
                    staff_ID = 2,
                    staff_FName = "Becky",
                    staff_LName = "Dolly",
                    staff_Gender = "Female",
                    de_ID = 1,
                    staff_Position = "HouseKeeper",
                    staff_Email = "becky@kousekeeper.com",
                    staff_Password = "Becky12345",
                    staff_Phone = "02156941",
                    staff_Address = "120 Hardy Street",
                },
                new Staff
                {
                    staff_ID = 3,
                    staff_FName = "Brandon",
                    staff_LName = "Dick",
                    staff_Gender = "Male",
                    de_ID = 2,
                    staff_Position = "Adminstrator",
                    staff_Email = "brandon@kousekeeper.com",
                    staff_Password = "Brandon12345",
                    staff_Phone = "02156941",
                    staff_Address = "120 Hamilton Street",
                }
                );
        }

    }
}

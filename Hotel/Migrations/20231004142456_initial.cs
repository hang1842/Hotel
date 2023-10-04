using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hotel.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusinessService",
                columns: table => new
                {
                    BS_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BS_Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BS_Rate = table.Column<decimal>(type: "decimal(3,2)", precision: 3, scale: 2, nullable: false),
                    BS_Price = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    BS_Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessService", x => x.BS_ID);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    de_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    de_Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.de_ID);
                });

            migrationBuilder.CreateTable(
                name: "Guest",
                columns: table => new
                {
                    GuestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Organization = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Hometown = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Preference = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guest", x => x.GuestID);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    MemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Organization = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.MemID);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    room_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    room_number = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    room_Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    room_Type = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    room_Price = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    room_Rate = table.Column<decimal>(type: "decimal(3,2)", precision: 3, scale: 2, nullable: false),
                    room_Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    room_Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.room_ID);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    staff_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    staff_FName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    staff_LName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    staff_Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    de_ID = table.Column<int>(type: "int", nullable: false),
                    staff_Position = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    staff_Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    staff_Password = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    staff_Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    staff_Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.staff_ID);
                    table.ForeignKey(
                        name: "FK_Staff_Department_de_ID",
                        column: x => x.de_ID,
                        principalTable: "Department",
                        principalColumn: "de_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consumption",
                columns: table => new
                {
                    con_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    guestID = table.Column<int>(type: "int", nullable: false),
                    BS_ID = table.Column<int>(type: "int", nullable: false),
                    Service_Quantity = table.Column<int>(type: "int", nullable: false),
                    con_Amount = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumption", x => x.con_ID);
                    table.ForeignKey(
                        name: "FK_Consumption_BusinessService_BS_ID",
                        column: x => x.BS_ID,
                        principalTable: "BusinessService",
                        principalColumn: "BS_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consumption_Guest_guestID",
                        column: x => x.guestID,
                        principalTable: "Guest",
                        principalColumn: "GuestID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    payment_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    guestID = table.Column<int>(type: "int", nullable: false),
                    Accommodation_days = table.Column<int>(type: "int", nullable: false),
                    Consumption_Charges = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    payment_Rate = table.Column<decimal>(type: "decimal(3,2)", precision: 3, scale: 2, nullable: false),
                    payment_Amount = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: false),
                    pay_method = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    paid_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.payment_ID);
                    table.ForeignKey(
                        name: "FK_Payment_Guest_guestID",
                        column: x => x.guestID,
                        principalTable: "Guest",
                        principalColumn: "GuestID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    bookID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemID = table.Column<int>(type: "int", nullable: false),
                    room_Type1 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    room_Quantity1 = table.Column<int>(type: "int", nullable: false),
                    room_Type2 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    room_Quantity2 = table.Column<int>(type: "int", nullable: false),
                    room_Type3 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    room_Quantity3 = table.Column<int>(type: "int", nullable: false),
                    CheckInTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOutTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CarPark = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.bookID);
                    table.ForeignKey(
                        name: "FK_Booking_Member_MemID",
                        column: x => x.MemID,
                        principalTable: "Member",
                        principalColumn: "MemID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CheckIn",
                columns: table => new
                {
                    CheckId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    guestID = table.Column<int>(type: "int", nullable: false),
                    roomID = table.Column<int>(type: "int", nullable: false),
                    CheckInDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOutDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    pre_payment_amount = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    pre_payment_method = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckIn", x => x.CheckId);
                    table.ForeignKey(
                        name: "FK_CheckIn_Guest_guestID",
                        column: x => x.guestID,
                        principalTable: "Guest",
                        principalColumn: "GuestID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckIn_Room_roomID",
                        column: x => x.roomID,
                        principalTable: "Room",
                        principalColumn: "room_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomService",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    staffID = table.Column<int>(type: "int", nullable: false),
                    RoomID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomService", x => x.ServiceId);
                    table.ForeignKey(
                        name: "FK_RoomService_Room_RoomID",
                        column: x => x.RoomID,
                        principalTable: "Room",
                        principalColumn: "room_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomService_Staff_staffID",
                        column: x => x.staffID,
                        principalTable: "Staff",
                        principalColumn: "staff_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BusinessService",
                columns: new[] { "BS_ID", "BS_Description", "BS_Name", "BS_Price", "BS_Rate" },
                values: new object[,]
                {
                    { 1, "Guests can order and deliver meals to their rooms.", "Customized Breakfast", 20m, 1m },
                    { 2, "Dry clean clothes for guests, iron them and deliver them to guest rooms.", "Dry-clean Services", 20m, 1m }
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "de_ID", "de_Name" },
                values: new object[,]
                {
                    { 1, "Customer Service Department" },
                    { 2, "IT Department" },
                    { 3, "Engineering Department" }
                });

            migrationBuilder.InsertData(
                table: "Guest",
                columns: new[] { "GuestID", "Email", "FName", "Gender", "Hometown", "ID", "LName", "Organization", "Phone", "Preference" },
                values: new object[,]
                {
                    { 1, "quentin@guest.com", "Quentin", "Male", "Christchurch", "025467895", "Jim", "Individual", "02146578", "Adventure" },
                    { 2, "alison@guest.com", "Alison", "Female", "Queenstown", "025467858", "Jim", "SIT", "0256487", "Music" }
                });

            migrationBuilder.InsertData(
                table: "Member",
                columns: new[] { "MemID", "Address", "Category", "Email", "FName", "Gender", "LName", "Organization", "Password", "Phone" },
                values: new object[,]
                {
                    { 1, "150 Eye Street, Invercargill", "Bronze", "alfred@member.com", "Alfred", "Male", "Ben", "Individual", "Alfred12345", "0236547" },
                    { 2, "1260 Eye Street, Christchurch", "Gold", "aditi@member.com", "Aditi", "Female", "Agatha", "SIT", "Aditi12345", "0236556" }
                });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "room_ID", "room_Description", "room_Name", "room_Price", "room_Rate", "room_Status", "room_Type", "room_number" },
                values: new object[,]
                {
                    { 1, "Sleeps 2,Free WiFi,Free self parking,36 sq m,1 King Bed", "Sunshine King", 168m, 1m, "Avacant Clean", "Single", "C-23" },
                    { 2, "Sleeps 2,Free WiFi,Free self parking,60 sq m,1 Twin Bed", "Sunshine Twin", 185m, 1m, "Occupied Clean", "Two Bedrooms", "B-32" }
                });

            migrationBuilder.InsertData(
                table: "Booking",
                columns: new[] { "bookID", "CarPark", "CheckInTime", "CheckOutTime", "MemID", "ReferenceNumber", "room_Quantity1", "room_Quantity2", "room_Quantity3", "room_Type1", "room_Type2", "room_Type3" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1998), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1991), 1, "IN20220123001", 1, 2, 0, "Single", "Two Bedrooms", "null" },
                    { 2, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2009), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2005), 2, "IN20231004005", 1, 0, 0, "Two Bedrooms", "null", "null" }
                });

            migrationBuilder.InsertData(
                table: "CheckIn",
                columns: new[] { "CheckId", "CheckInDate", "CheckOutDate", "guestID", "pre_payment_amount", "pre_payment_method", "roomID" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 150m, "Credit Card", 2 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 150m, "Credit Card", 1 }
                });

            migrationBuilder.InsertData(
                table: "Consumption",
                columns: new[] { "con_ID", "BS_ID", "Service_Quantity", "con_Amount", "guestID" },
                values: new object[,]
                {
                    { 1, 1, 2, 40m, 1 },
                    { 2, 2, 1, 50m, 2 }
                });

            migrationBuilder.InsertData(
                table: "Payment",
                columns: new[] { "payment_ID", "Accommodation_days", "Consumption_Charges", "create_date", "guestID", "paid_date", "pay_method", "payment_Amount", "payment_Rate" },
                values: new object[,]
                {
                    { 1, 5, 45m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cash", 250m, 1m },
                    { 2, 0, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", 0m, 1m }
                });

            migrationBuilder.InsertData(
                table: "Staff",
                columns: new[] { "staff_ID", "de_ID", "staff_Address", "staff_Email", "staff_FName", "staff_Gender", "staff_LName", "staff_Password", "staff_Phone", "staff_Position" },
                values: new object[,]
                {
                    { 1, 3, "120 Wilfrid Street", "ben@kousekeeper.com", "Ben", "Male", "Cary", "Ben12345", "02156941", "Manager" },
                    { 2, 1, "120 Hardy Street", "becky@kousekeeper.com", "Becky", "Female", "Dolly", "Becky12345", "02156941", "HouseKeeper" },
                    { 3, 2, "120 Hamilton Street", "brandon@kousekeeper.com", "Brandon", "Male", "Dick", "Brandon12345", "02156941", "Adminstrator" }
                });

            migrationBuilder.InsertData(
                table: "RoomService",
                columns: new[] { "ServiceId", "RoomID", "Status", "Type", "staffID" },
                values: new object[,]
                {
                    { 1, 1, "Execeting", "Clear", 1 },
                    { 2, 1, "Execeting", "Maintenance", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_MemID",
                table: "Booking",
                column: "MemID");

            migrationBuilder.CreateIndex(
                name: "IX_CheckIn_guestID",
                table: "CheckIn",
                column: "guestID");

            migrationBuilder.CreateIndex(
                name: "IX_CheckIn_roomID",
                table: "CheckIn",
                column: "roomID");

            migrationBuilder.CreateIndex(
                name: "IX_Consumption_BS_ID",
                table: "Consumption",
                column: "BS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Consumption_guestID",
                table: "Consumption",
                column: "guestID");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_guestID",
                table: "Payment",
                column: "guestID");

            migrationBuilder.CreateIndex(
                name: "IX_RoomService_RoomID",
                table: "RoomService",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_RoomService_staffID",
                table: "RoomService",
                column: "staffID");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_de_ID",
                table: "Staff",
                column: "de_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "CheckIn");

            migrationBuilder.DropTable(
                name: "Consumption");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "RoomService");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "BusinessService");

            migrationBuilder.DropTable(
                name: "Guest");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}

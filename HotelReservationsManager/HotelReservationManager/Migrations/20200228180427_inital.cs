using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelReservationManager.Migrations
{
    public partial class inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacity = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    IsFree = table.Column<bool>(nullable: false),
                    PriceForAdult = table.Column<decimal>(nullable: false),
                    PriceForChild = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Forename = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    SurName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    AppointmentDate = table.Column<DateTime>(nullable: false),
                    IsActiveAccount = table.Column<bool>(nullable: false),
                    DateOfDismissal = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservedRoomId = table.Column<int>(nullable: true),
                    ReservationMakerId = table.Column<int>(nullable: true),
                    DateОfАccommodation = table.Column<DateTime>(nullable: false),
                    ReleaseDate = table.Column<DateTime>(nullable: false),
                    IsbreakfastIncluded = table.Column<bool>(nullable: false),
                    AllInclusive = table.Column<bool>(nullable: false),
                    DueAmount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Users_ReservationMakerId",
                        column: x => x.ReservationMakerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_Rooms_ReservedRoomId",
                        column: x => x.ReservedRoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Forename = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    SurName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    IsAdult = table.Column<bool>(nullable: false),
                    ReservationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ReservationId",
                table: "Clients",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ReservationMakerId",
                table: "Reservations",
                column: "ReservationMakerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ReservedRoomId",
                table: "Reservations",
                column: "ReservedRoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}

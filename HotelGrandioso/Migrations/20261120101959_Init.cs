using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelGrandioso.Migrations;

/// <inheritdoc />
public partial class _20261120101959_Init : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Guests",
            columns: table => new
            {
                Id = table.Column<int>(type: "INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                Name = table.Column<string>(type: "TEXT", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Guests", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "RoomTypes",
            columns: table => new
            {
                RoomTypeId = table.Column<int>(type: "INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                Name = table.Column<string>(type: "TEXT", nullable: false),
                Description = table.Column<string>(type: "TEXT", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_RoomTypes", x => x.RoomTypeId);
            });

        migrationBuilder.CreateTable(
            name: "Rooms",
            columns: table => new
            {
                RoomId = table.Column<int>(type: "INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                RoomTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                RoomNumber = table.Column<int>(type: "INTEGER", nullable: false),
                Floor = table.Column<int>(type: "INTEGER", nullable: false),
                SizeM2 = table.Column<int>(type: "INTEGER", nullable: false),
                PricePerNight = table.Column<int>(type: "INTEGER", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Rooms", x => x.RoomId);
                table.ForeignKey(
                    name: "FK_Rooms_RoomTypes_RoomTypeId",
                    column: x => x.RoomTypeId,
                    principalTable: "RoomTypes",
                    principalColumn: "RoomTypeId",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Bookings",
            columns: table => new
            {
                BookingId = table.Column<int>(type: "INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                GuestId = table.Column<int>(type: "INTEGER", nullable: false),
                CheckIn = table.Column<DateTime>(type: "TEXT", nullable: false),
                CheckOut = table.Column<DateTime>(type: "TEXT", nullable: false),
                RoomId = table.Column<int>(type: "INTEGER", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Bookings", x => x.BookingId);
                table.ForeignKey(
                    name: "FK_Bookings_Guests_GuestId",
                    column: x => x.GuestId,
                    principalTable: "Guests",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Bookings_Rooms_RoomId",
                    column: x => x.RoomId,
                    principalTable: "Rooms",
                    principalColumn: "RoomId",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Bookings_GuestId",
            table: "Bookings",
            column: "GuestId");

        migrationBuilder.CreateIndex(
            name: "IX_Bookings_RoomId",
            table: "Bookings",
            column: "RoomId");

        migrationBuilder.CreateIndex(
            name: "IX_Rooms_RoomTypeId",
            table: "Rooms",
            column: "RoomTypeId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Bookings");

        migrationBuilder.DropTable(
            name: "Guests");

        migrationBuilder.DropTable(
            name: "Rooms");

        migrationBuilder.DropTable(
            name: "RoomTypes");
    }
}

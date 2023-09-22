using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoomBookingRepoNtier.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class NamingConventionEdited : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Rooms_RoomModelId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Bookings_BookingModelId",
                table: "Participants");

            migrationBuilder.RenameColumn(
                name: "BookingModelId",
                table: "Participants",
                newName: "BookingEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Participants_BookingModelId",
                table: "Participants",
                newName: "IX_Participants_BookingEntityId");

            migrationBuilder.RenameColumn(
                name: "RoomModelId",
                table: "Bookings",
                newName: "RoomEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_RoomModelId",
                table: "Bookings",
                newName: "IX_Bookings_RoomEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Rooms_RoomEntityId",
                table: "Bookings",
                column: "RoomEntityId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Bookings_BookingEntityId",
                table: "Participants",
                column: "BookingEntityId",
                principalTable: "Bookings",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Rooms_RoomEntityId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Bookings_BookingEntityId",
                table: "Participants");

            migrationBuilder.RenameColumn(
                name: "BookingEntityId",
                table: "Participants",
                newName: "BookingModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Participants_BookingEntityId",
                table: "Participants",
                newName: "IX_Participants_BookingModelId");

            migrationBuilder.RenameColumn(
                name: "RoomEntityId",
                table: "Bookings",
                newName: "RoomModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_RoomEntityId",
                table: "Bookings",
                newName: "IX_Bookings_RoomModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Rooms_RoomModelId",
                table: "Bookings",
                column: "RoomModelId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Bookings_BookingModelId",
                table: "Participants",
                column: "BookingModelId",
                principalTable: "Bookings",
                principalColumn: "Id");
        }
    }
}

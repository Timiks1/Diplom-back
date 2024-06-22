using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityACS.API.Migrations
{
    /// <inheritdoc />
    public partial class chat3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chat_AspNetUsers_TeacherId",
                table: "Chat");

            migrationBuilder.DropIndex(
                name: "IX_Chat_TeacherId",
                table: "Chat");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Chat");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeCreation",
                table: "Chat",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ReceiverId",
                table: "Chat",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SenderId",
                table: "Chat",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3ffb0f7d-f0e8-42a6-addf-16e03b1d342e", "AQAAAAIAAYagAAAAEN2huz7rj6ms1etoHeJQL+0ON46HeoLtYMhXKC70j8GmiwtzURHB58OowkyIyO/TKQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_Chat_ReceiverId",
                table: "Chat",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Chat_SenderId",
                table: "Chat",
                column: "SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chat_AspNetUsers_ReceiverId",
                table: "Chat",
                column: "ReceiverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chat_AspNetUsers_SenderId",
                table: "Chat",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chat_AspNetUsers_ReceiverId",
                table: "Chat");

            migrationBuilder.DropForeignKey(
                name: "FK_Chat_AspNetUsers_SenderId",
                table: "Chat");

            migrationBuilder.DropIndex(
                name: "IX_Chat_ReceiverId",
                table: "Chat");

            migrationBuilder.DropIndex(
                name: "IX_Chat_SenderId",
                table: "Chat");

            migrationBuilder.DropColumn(
                name: "ReceiverId",
                table: "Chat");

            migrationBuilder.DropColumn(
                name: "SenderId",
                table: "Chat");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeCreation",
                table: "Chat",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddColumn<Guid>(
                name: "TeacherId",
                table: "Chat",
                type: "uuid",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "50426fa1-ab42-455a-a4b7-5525c414c1ec", "AQAAAAIAAYagAAAAEJIYZqznrkvl1qkpIGHdsLkKFBbyO1UjRFXt6/km2/TpM7DX+1K4NODottJEkLaIPw==" });

            migrationBuilder.CreateIndex(
                name: "IX_Chat_TeacherId",
                table: "Chat",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chat_AspNetUsers_TeacherId",
                table: "Chat",
                column: "TeacherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityACS.API.Migrations
{
    /// <inheritdoc />
    public partial class update11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DisciplineId",
                table: "TeacherTests",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Patronymic",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Chat",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: false),
                    TeacherId = table.Column<Guid>(type: "uuid", nullable: true),
                    TimeCreation = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chat_AspNetUsers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Patronymic" },
                values: new object[] { "c7cda0c0-709a-43b1-bb74-8f604280504d", "AQAAAAIAAYagAAAAEIGOKJZ9x7iU/eZEEgSOMza3iLWQCGpDXSRiOnXmBCuvPWnDELzIXqpklVzgs0WivA==", null });

            migrationBuilder.CreateIndex(
                name: "IX_TeacherTests_DisciplineId",
                table: "TeacherTests",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_Chat_TeacherId",
                table: "Chat",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherTests_Disciplines_DisciplineId",
                table: "TeacherTests",
                column: "DisciplineId",
                principalTable: "Disciplines",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherTests_Disciplines_DisciplineId",
                table: "TeacherTests");

            migrationBuilder.DropTable(
                name: "Chat");

            migrationBuilder.DropIndex(
                name: "IX_TeacherTests_DisciplineId",
                table: "TeacherTests");

            migrationBuilder.DropColumn(
                name: "DisciplineId",
                table: "TeacherTests");

            migrationBuilder.DropColumn(
                name: "Patronymic",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "162adc90-7d81-4038-bc4a-6d39cad11dda", "AQAAAAIAAYagAAAAECxiPQYtQMetXmfJ6CTmzKNzwohiPXp1ClpLv/4uil39+tsiUits4KmRDHHJW4zDtA==" });
        }
    }
}

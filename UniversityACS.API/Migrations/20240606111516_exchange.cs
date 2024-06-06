using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityACS.API.Migrations
{
    /// <inheritdoc />
    public partial class exchange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExchangeVisitsPlanReviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TeacherId = table.Column<Guid>(type: "uuid", nullable: true),
                    ExchangeVisitsPlan = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    File = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExchangeVisitsPlanReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExchangeVisitsPlanReviews_AspNetUsers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "67fd7772-c94d-4cb2-a977-992c096a6548", "AQAAAAIAAYagAAAAEFWAQYzY2ng0FiqK+J0zgoabPBmKan36EgcdPDijOh8ovIMpdQYElOufv58PS3Vt7w==" });

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeVisitsPlanReviews_TeacherId",
                table: "ExchangeVisitsPlanReviews",
                column: "TeacherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExchangeVisitsPlanReviews");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "adbf45ab-29bf-4001-8cc3-8d382b123768", "AQAAAAIAAYagAAAAEGwo0DkLTcq1Gwyip7y68dkXSHD5JStqYYqBN/tJ+6TD6mMonSDutckHfdvIbh2oHQ==" });
        }
    }
}

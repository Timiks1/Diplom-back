using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityACS.API.Migrations
{
    /// <inheritdoc />
    public partial class photo3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "AspNetUsers",
                type: "bytea",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Photo" },
                values: new object[] { "038086f0-c44c-4741-9d5a-16f71627c673", "AQAAAAIAAYagAAAAECF7/aAfj1hxFQjGYl5NXm2fsA5RJrM2302CZyoqbX7Mbcvcmj/nMKzMweJvHohfdA==", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ef321d60-7318-4c21-b97a-ff3ef6602345", "AQAAAAIAAYagAAAAEEpyP5MtxTO5v9g9PqSmatmZBCqVMNb08WPY5HxGAsISDC3vA0Nk1V7BZDxfS6KYTw==" });
        }
    }
}

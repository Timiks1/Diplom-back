using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityACS.API.Migrations
{
    /// <inheritdoc />
    public partial class disciplines4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b4a2f91b-edb6-4e89-ac2d-c946a4e3802b", "AQAAAAIAAYagAAAAEKlBRFkfDkvagkIPbBit8kutK+VV46Aa0wlDmtqk5oK+A65niUiklFSlEGPbLZFoCQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e5907487-ae28-4ef7-a22d-9b4ba7f0b255", "AQAAAAIAAYagAAAAEOYg3+aS5BoktCg0/L09BsKn3IOKW2/kw5NZ0O4DEOV4ILzbWD1HCml8L24BWciDVA==" });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityACS.API.Migrations
{
    /// <inheritdoc />
    public partial class upgrade3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6b26b697-cb75-4f42-96fd-2c6fa1f711a6", "AQAAAAIAAYagAAAAEBIIeQ+jzhIS9FaoPRIOOa/Si+W64OWBc/sLzxTBq29hc+N8PvK9eMq6SGeqJylLJw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6dfa5b9c-b7da-4223-a4e0-931a87ddd534", "AQAAAAIAAYagAAAAEI3HR9m8xv6Mx/a0xxddnKdQMPw0ydb/0TFIujK+eGgPsaH1JhFY9HiMiHO7zOCd5w==" });
        }
    }
}

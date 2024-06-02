using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityACS.API.Migrations
{
    /// <inheritdoc />
    public partial class upgrade4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5d39363e-cb24-4735-8d2b-e6c50f3e816b", "AQAAAAIAAYagAAAAEEwBH/S6SV6LHQyEYKhsxqMeHLvy5TrrXLRODXZNqlzaC3naGOeujfP0G6MD5+JAwA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6b26b697-cb75-4f42-96fd-2c6fa1f711a6", "AQAAAAIAAYagAAAAEBIIeQ+jzhIS9FaoPRIOOa/Si+W64OWBc/sLzxTBq29hc+N8PvK9eMq6SGeqJylLJw==" });
        }
    }
}

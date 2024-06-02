using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityACS.API.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentsGroupRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6855a453-45c5-4757-a252-cbdf89d15f17", "AQAAAAIAAYagAAAAEHTq6W4+6Hz2GmdbcblOmFjmbp8h2n15jl8NXNQJA8agXuInTe+aL4xQmq6rmWrRaw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5d39363e-cb24-4735-8d2b-e6c50f3e816b", "AQAAAAIAAYagAAAAEEwBH/S6SV6LHQyEYKhsxqMeHLvy5TrrXLRODXZNqlzaC3naGOeujfP0G6MD5+JAwA==" });
        }
    }
}

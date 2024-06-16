using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityACS.API.Migrations
{
    /// <inheritdoc />
    public partial class moreUserInfo2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0b5fd978-779a-4e28-8b08-6046b169c416", "AQAAAAIAAYagAAAAEE+GzoC/Q2tHALDmsAaQX0zKL4+a0e9GPeGikYbR6ACHB5yZ7/bI/jVsFpiKhyPjMA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b28adf4d-05f3-4c3a-b60d-d772d83846f7", "AQAAAAIAAYagAAAAEK9POMv07c4rljB8ylRy1herhcgwUXNrKDvH1cTlUZF3VeSyMFKX7ZT7nrS2uPCLUw==" });
        }
    }
}

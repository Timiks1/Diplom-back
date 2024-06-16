using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityACS.API.Migrations
{
    /// <inheritdoc />
    public partial class moreUserInfo3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8f057f2d-f5ad-496b-937f-3a7c254fc731", "AQAAAAIAAYagAAAAEHmEbGUMrR5tSr7NjT2CUYmJUkxhll3W9/lnK1QVr49rciScz1FRTrjS7ua/H5ZqJA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0b5fd978-779a-4e28-8b08-6046b169c416", "AQAAAAIAAYagAAAAEE+GzoC/Q2tHALDmsAaQX0zKL4+a0e9GPeGikYbR6ACHB5yZ7/bI/jVsFpiKhyPjMA==" });
        }
    }
}

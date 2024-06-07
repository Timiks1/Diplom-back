using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityACS.API.Migrations
{
    /// <inheritdoc />
    public partial class userInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d8798e46-9100-475b-9c74-c26381c363fc", "AQAAAAIAAYagAAAAEESgGGp8NvmJ1OjJnNsB4oBauQ3VBuToEPw1w9/tr56FvyJ+F5f9DlBw+svECC3lqg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "038086f0-c44c-4741-9d5a-16f71627c673", "AQAAAAIAAYagAAAAECF7/aAfj1hxFQjGYl5NXm2fsA5RJrM2302CZyoqbX7Mbcvcmj/nMKzMweJvHohfdA==" });
        }
    }
}

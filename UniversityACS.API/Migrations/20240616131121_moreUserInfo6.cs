using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityACS.API.Migrations
{
    /// <inheritdoc />
    public partial class moreUserInfo6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cedbba79-5a91-469c-a14c-34df4a15d2c9", "AQAAAAIAAYagAAAAEAq9DIoUrKpToKmscd7hXIwE5nA2Y7lVKhAlHN7SYEvwH3z46iis2/6Vc64M/yKt+A==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a1600736-d778-4bb7-83df-ce7b9bc63750", "AQAAAAIAAYagAAAAEI2rNU8kunfL0rBHYRSK7qWaqKxJQOMg/rCuMw5Ledz/1JBd3kt0F4zzJ/aAq0QwPA==" });
        }
    }
}

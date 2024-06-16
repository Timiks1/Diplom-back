using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityACS.API.Migrations
{
    /// <inheritdoc />
    public partial class moreUserInfo5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a1600736-d778-4bb7-83df-ce7b9bc63750", "AQAAAAIAAYagAAAAEI2rNU8kunfL0rBHYRSK7qWaqKxJQOMg/rCuMw5Ledz/1JBd3kt0F4zzJ/aAq0QwPA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0ef44833-5645-41b1-9a91-b77e33a637a9", "AQAAAAIAAYagAAAAEEOzaicJwefgH9gJhO2wU0nDwljzSOYjl74OsBIpJ1ToTqJGBGaZtsVIOTpKpxMiBg==" });
        }
    }
}

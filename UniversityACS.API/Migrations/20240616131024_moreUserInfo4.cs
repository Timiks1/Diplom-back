using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityACS.API.Migrations
{
    /// <inheritdoc />
    public partial class moreUserInfo4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0ef44833-5645-41b1-9a91-b77e33a637a9", "AQAAAAIAAYagAAAAEEOzaicJwefgH9gJhO2wU0nDwljzSOYjl74OsBIpJ1ToTqJGBGaZtsVIOTpKpxMiBg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8f057f2d-f5ad-496b-937f-3a7c254fc731", "AQAAAAIAAYagAAAAEHmEbGUMrR5tSr7NjT2CUYmJUkxhll3W9/lnK1QVr49rciScz1FRTrjS7ua/H5ZqJA==" });
        }
    }
}

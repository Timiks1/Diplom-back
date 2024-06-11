using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityACS.API.Migrations
{
    /// <inheritdoc />
    public partial class disciplines2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4507b1c4-82a9-46ee-9204-b111537f24f2", "AQAAAAIAAYagAAAAEA3IcfyMTu9NqIH3h6m4lm5jwGvB/ZSo826mm9GLDCBgTfwe0dWEFk1Yawb01di6Tg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "87ce9dce-2ac6-4280-ba02-2c03eec6ca4c", "AQAAAAIAAYagAAAAEFCol7O914L3MTHZaku5HlSBiPX+HxDwWFDLO0lhuDxAFIMZVO0eZ59oySZNf4HNsg==" });
        }
    }
}

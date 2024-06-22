using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityACS.API.Migrations
{
    /// <inheritdoc />
    public partial class chat2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "50426fa1-ab42-455a-a4b7-5525c414c1ec", "AQAAAAIAAYagAAAAEJIYZqznrkvl1qkpIGHdsLkKFBbyO1UjRFXt6/km2/TpM7DX+1K4NODottJEkLaIPw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ef0e34d8-a1ab-49ea-a582-cdd34369795c", "AQAAAAIAAYagAAAAEGDD9IelFml+lnLx6I9dldFuobVit5JWRJ5Tbm2fivxQvxxppJbd7PHeDGOBjG2OvA==" });
        }
    }
}

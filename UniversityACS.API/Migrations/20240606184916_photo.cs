using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityACS.API.Migrations
{
    /// <inheritdoc />
    public partial class photo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "12baeb3a-e0bf-460e-bcf1-c10d37a00f49", "AQAAAAIAAYagAAAAEB8SlgQ1US0H0fmppj9tFKFb2GrNszSt0/QK326Z/x1lP3KeSrnK5Uy37/+ghJ3K/g==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "35074f5a-5118-456c-b258-d1c9450f49aa", "AQAAAAIAAYagAAAAEHSZlqYQYjiT7WJKuXmUy9gFa+OQOKH/6j3IPi7amyXe8V/oNosLc7Gg9nsMZl0e2g==" });
        }
    }
}

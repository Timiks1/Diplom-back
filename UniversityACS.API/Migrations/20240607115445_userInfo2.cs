using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityACS.API.Migrations
{
    /// <inheritdoc />
    public partial class userInfo2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "681be9a1-8761-412e-b0be-c9bb7c1e4925", "AQAAAAIAAYagAAAAEDjpb19M7r1PHtUR+n8ShKS+AO1hTbcPq6tFdvkqBRxRyMept0D2j2X924iteELtVQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d8798e46-9100-475b-9c74-c26381c363fc", "AQAAAAIAAYagAAAAEESgGGp8NvmJ1OjJnNsB4oBauQ3VBuToEPw1w9/tr56FvyJ+F5f9DlBw+svECC3lqg==" });
        }
    }
}

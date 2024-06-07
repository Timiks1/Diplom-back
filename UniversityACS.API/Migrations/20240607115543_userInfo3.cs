using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityACS.API.Migrations
{
    /// <inheritdoc />
    public partial class userInfo3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Course",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EducationTime",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UnHiddenPassword",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "Age", "ConcurrencyStamp", "Course", "EducationTime", "PasswordHash", "UnHiddenPassword" },
                values: new object[] { null, "87ce9dce-2ac6-4280-ba02-2c03eec6ca4c", null, null, "AQAAAAIAAYagAAAAEFCol7O914L3MTHZaku5HlSBiPX+HxDwWFDLO0lhuDxAFIMZVO0eZ59oySZNf4HNsg==", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Course",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EducationTime",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UnHiddenPassword",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "681be9a1-8761-412e-b0be-c9bb7c1e4925", "AQAAAAIAAYagAAAAEDjpb19M7r1PHtUR+n8ShKS+AO1hTbcPq6tFdvkqBRxRyMept0D2j2X924iteELtVQ==" });
        }
    }
}

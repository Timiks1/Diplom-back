using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityACS.API.Migrations
{
    /// <inheritdoc />
    public partial class cirrilculum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bd2864d5-40b9-4968-927a-6699856888a9", "AQAAAAIAAYagAAAAEGqK3LiA1Npupm9Ey0c45hRM2zTLycott9SUkKjcEZK0Y6PeX6vcDx294f/BZNuICg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "67fd7772-c94d-4cb2-a977-992c096a6548", "AQAAAAIAAYagAAAAEFWAQYzY2ng0FiqK+J0zgoabPBmKan36EgcdPDijOh8ovIMpdQYElOufv58PS3Vt7w==" });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityACS.API.Migrations
{
    /// <inheritdoc />
    public partial class cirrilculum2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileFormat",
                table: "WorkingCurricula",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "LessonId",
                table: "WorkingCurricula",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "35074f5a-5118-456c-b258-d1c9450f49aa", "AQAAAAIAAYagAAAAEHSZlqYQYjiT7WJKuXmUy9gFa+OQOKH/6j3IPi7amyXe8V/oNosLc7Gg9nsMZl0e2g==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileFormat",
                table: "WorkingCurricula");

            migrationBuilder.DropColumn(
                name: "LessonId",
                table: "WorkingCurricula");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bd2864d5-40b9-4968-927a-6699856888a9", "AQAAAAIAAYagAAAAEGqK3LiA1Npupm9Ey0c45hRM2zTLycott9SUkKjcEZK0Y6PeX6vcDx294f/BZNuICg==" });
        }
    }
}

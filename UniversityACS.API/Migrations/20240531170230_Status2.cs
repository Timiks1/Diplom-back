using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityACS.API.Migrations
{
    /// <inheritdoc />
    public partial class Status2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "TeacherTests",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "dc8991ab-d191-4224-9c16-a55b379efc3c", "AQAAAAIAAYagAAAAEK51q+WB93FLQiEpkBJhHpOQh1wtpqjYXnMBoDfS9++JyDlRyHTU8H9+FKuE+MpUmg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "TeacherTests");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ad1dee02-19b2-4a63-8882-89b0d6d9d652", "AQAAAAIAAYagAAAAEJxGDCsznE79r3p4MguiV30dK0dsBepeRjypje1zojarSjl31QI3OrhL4ihcVB0Dhw==" });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityACS.API.Migrations
{
    /// <inheritdoc />
    public partial class updateLessons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_HomeWorks_HomeWorkId",
                table: "Lessons");

            migrationBuilder.AlterColumn<Guid>(
                name: "HomeWorkId",
                table: "Lessons",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "45b68b43-57e7-4768-9a41-b85b35c75724", "AQAAAAIAAYagAAAAEM+Kl3uNsg5kvW2O3Ez8IsL8mAeswPbaUcimZVszfpX6FPoYyi7+c5qPK4JXXmM+wA==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_HomeWorks_HomeWorkId",
                table: "Lessons",
                column: "HomeWorkId",
                principalTable: "HomeWorks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_HomeWorks_HomeWorkId",
                table: "Lessons");

            migrationBuilder.AlterColumn<Guid>(
                name: "HomeWorkId",
                table: "Lessons",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f3b19c70-23a8-4e51-8da7-67a0302cdc03", "AQAAAAIAAYagAAAAEA6Koyjb1sPuBfrh5PhsdodxdQjcGoAP1sr9azy1RncBO7SjDyTtl3/gnRHT7+06Qg==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_HomeWorks_HomeWorkId",
                table: "Lessons",
                column: "HomeWorkId",
                principalTable: "HomeWorks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

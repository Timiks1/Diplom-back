using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityACS.API.Migrations
{
    /// <inheritdoc />
    public partial class disciplines : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentsGroups_Disciplines_DisciplineId",
                table: "StudentsGroups");

            migrationBuilder.DropIndex(
                name: "IX_StudentsGroups_DisciplineId",
                table: "StudentsGroups");

            migrationBuilder.DropColumn(
                name: "DisciplineId",
                table: "StudentsGroups");

            migrationBuilder.CreateTable(
                name: "DisciplineStudentsGroup",
                columns: table => new
                {
                    DisciplinesId = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentsGroupsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplineStudentsGroup", x => new { x.DisciplinesId, x.StudentsGroupsId });
                    table.ForeignKey(
                        name: "FK_DisciplineStudentsGroup_Disciplines_DisciplinesId",
                        column: x => x.DisciplinesId,
                        principalTable: "Disciplines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DisciplineStudentsGroup_StudentsGroups_StudentsGroupsId",
                        column: x => x.StudentsGroupsId,
                        principalTable: "StudentsGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f3b19c70-23a8-4e51-8da7-67a0302cdc03", "AQAAAAIAAYagAAAAEA6Koyjb1sPuBfrh5PhsdodxdQjcGoAP1sr9azy1RncBO7SjDyTtl3/gnRHT7+06Qg==" });

            migrationBuilder.CreateIndex(
                name: "IX_DisciplineStudentsGroup_StudentsGroupsId",
                table: "DisciplineStudentsGroup",
                column: "StudentsGroupsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DisciplineStudentsGroup");

            migrationBuilder.AddColumn<Guid>(
                name: "DisciplineId",
                table: "StudentsGroups",
                type: "uuid",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4ea0ec17-a48c-4856-8e10-463afe38d99e", "AQAAAAIAAYagAAAAEKmYBRLkaynNRTuJ0zGvC4jsVCKvYyOEmK1fdsdmQN6MeH57cf8ySASCegBLzuGKhw==" });

            migrationBuilder.CreateIndex(
                name: "IX_StudentsGroups_DisciplineId",
                table: "StudentsGroups",
                column: "DisciplineId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsGroups_Disciplines_DisciplineId",
                table: "StudentsGroups",
                column: "DisciplineId",
                principalTable: "Disciplines",
                principalColumn: "Id");
        }
    }
}

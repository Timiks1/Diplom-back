using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityACS.API.Migrations
{
    /// <inheritdoc />
    public partial class disciplines5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DisciplineStudentsGroup");

            migrationBuilder.AddColumn<string>(
                name: "AuditoryTasks",
                table: "Disciplines",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ECTS",
                table: "Disciplines",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Exams",
                table: "Disciplines",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IndependentHours",
                table: "Disciplines",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LaboratoryHours",
                table: "Disciplines",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LecturerHours",
                table: "Disciplines",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PracticHours",
                table: "Disciplines",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StudentsGroupId",
                table: "Disciplines",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tests",
                table: "Disciplines",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2c32fbf4-f4f6-4c1e-8b0c-df5b76fb5792", "AQAAAAIAAYagAAAAEOeuBVVLtIZHT1yHBA4T3x4QyGi2O8jfwicK/HX+GOm2pRrDgaXMytCgyX39OShSLA==" });

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_StudentsGroupId",
                table: "Disciplines",
                column: "StudentsGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplines_StudentsGroups_StudentsGroupId",
                table: "Disciplines",
                column: "StudentsGroupId",
                principalTable: "StudentsGroups",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplines_StudentsGroups_StudentsGroupId",
                table: "Disciplines");

            migrationBuilder.DropIndex(
                name: "IX_Disciplines_StudentsGroupId",
                table: "Disciplines");

            migrationBuilder.DropColumn(
                name: "AuditoryTasks",
                table: "Disciplines");

            migrationBuilder.DropColumn(
                name: "ECTS",
                table: "Disciplines");

            migrationBuilder.DropColumn(
                name: "Exams",
                table: "Disciplines");

            migrationBuilder.DropColumn(
                name: "IndependentHours",
                table: "Disciplines");

            migrationBuilder.DropColumn(
                name: "LaboratoryHours",
                table: "Disciplines");

            migrationBuilder.DropColumn(
                name: "LecturerHours",
                table: "Disciplines");

            migrationBuilder.DropColumn(
                name: "PracticHours",
                table: "Disciplines");

            migrationBuilder.DropColumn(
                name: "StudentsGroupId",
                table: "Disciplines");

            migrationBuilder.DropColumn(
                name: "Tests",
                table: "Disciplines");

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
                values: new object[] { "b4a2f91b-edb6-4e89-ac2d-c946a4e3802b", "AQAAAAIAAYagAAAAEKlBRFkfDkvagkIPbBit8kutK+VV46Aa0wlDmtqk5oK+A65niUiklFSlEGPbLZFoCQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_DisciplineStudentsGroup_StudentsGroupsId",
                table: "DisciplineStudentsGroup",
                column: "StudentsGroupsId");
        }
    }
}

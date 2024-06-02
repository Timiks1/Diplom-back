using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityACS.API.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentsGroupRelations2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentsGroupStudents",
                columns: table => new
                {
                    StudentsGroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsGroupStudents", x => new { x.StudentsGroupId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_StudentsGroupStudents_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentsGroupStudents_StudentsGroups_StudentsGroupId",
                        column: x => x.StudentsGroupId,
                        principalTable: "StudentsGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentsGroupDisciplines",
                columns: table => new
                {
                    StudentsGroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    DisciplineId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsGroupDisciplines", x => new { x.StudentsGroupId, x.DisciplineId });
                    table.ForeignKey(
                        name: "FK_StudentsGroupDisciplines_Disciplines_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Disciplines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentsGroupDisciplines_StudentsGroups_StudentsGroupId",
                        column: x => x.StudentsGroupId,
                        principalTable: "StudentsGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentsGroupStudents_StudentId",
                table: "StudentsGroupStudents",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsGroupDisciplines_DisciplineId",
                table: "StudentsGroupDisciplines",
                column: "DisciplineId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentsGroupStudents");

            migrationBuilder.DropTable(
                name: "StudentsGroupDisciplines");
        }
    }
}

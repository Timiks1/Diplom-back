using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityACS.API.Migrations
{
    /// <inheritdoc />
    public partial class fixDiscipline : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplines_StudentsGroups_StudentsGroupId",
                table: "Disciplines");

            migrationBuilder.DropIndex(
                name: "IX_Disciplines_StudentsGroupId",
                table: "Disciplines");

            migrationBuilder.DropColumn(
                name: "StudentsGroupId",
                table: "Disciplines");

            migrationBuilder.CreateTable(
                name: "DisciplineStudentsGroup",
                columns: table => new
                {
                    DisciplinesId = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentsGroupId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplineStudentsGroup", x => new { x.DisciplinesId, x.StudentsGroupId });
                    table.ForeignKey(
                        name: "FK_DisciplineStudentsGroup_Disciplines_DisciplinesId",
                        column: x => x.DisciplinesId,
                        principalTable: "Disciplines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DisciplineStudentsGroup_StudentsGroups_StudentsGroupId",
                        column: x => x.StudentsGroupId,
                        principalTable: "StudentsGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "44c64478-0005-4325-ae41-dda2e0755d63", "AQAAAAIAAYagAAAAEPhXLHjpX+VoFJ9NkUVEt9fO+lSj4Hx6XVIbXpg4ss9dm0h/J8PkEftpxZ2mHdh/yQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_DisciplineStudentsGroup_StudentsGroupId",
                table: "DisciplineStudentsGroup",
                column: "StudentsGroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DisciplineStudentsGroup");

            migrationBuilder.AddColumn<Guid>(
                name: "StudentsGroupId",
                table: "Disciplines",
                type: "uuid",
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
    }
}

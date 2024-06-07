using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityACS.API.Migrations
{
    /// <inheritdoc />
    public partial class fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentsGroupDisciplines");

            migrationBuilder.DropTable(
                name: "StudentsGroupStudents");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "StudentsGroups",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "StudentsGroups",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DisciplineId",
                table: "StudentsGroups",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GroupId",
                table: "AspNetUsers",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StudentsGroupId",
                table: "AspNetUsers",
                type: "uuid",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "GroupId", "PasswordHash", "StudentsGroupId" },
                values: new object[] { "4ea0ec17-a48c-4856-8e10-463afe38d99e", null, "AQAAAAIAAYagAAAAEKmYBRLkaynNRTuJ0zGvC4jsVCKvYyOEmK1fdsdmQN6MeH57cf8ySASCegBLzuGKhw==", null });

            migrationBuilder.CreateIndex(
                name: "IX_StudentsGroups_DisciplineId",
                table: "StudentsGroups",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_StudentsGroupId",
                table: "AspNetUsers",
                column: "StudentsGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_StudentsGroups_StudentsGroupId",
                table: "AspNetUsers",
                column: "StudentsGroupId",
                principalTable: "StudentsGroups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsGroups_Disciplines_DisciplineId",
                table: "StudentsGroups",
                column: "DisciplineId",
                principalTable: "Disciplines",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_StudentsGroups_StudentsGroupId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentsGroups_Disciplines_DisciplineId",
                table: "StudentsGroups");

            migrationBuilder.DropIndex(
                name: "IX_StudentsGroups_DisciplineId",
                table: "StudentsGroups");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_StudentsGroupId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DisciplineId",
                table: "StudentsGroups");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StudentsGroupId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "StudentsGroups",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "StudentsGroups",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "StudentsGroupDisciplines",
                columns: table => new
                {
                    DisciplinesId = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentsGroupsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsGroupDisciplines", x => new { x.DisciplinesId, x.StudentsGroupsId });
                    table.ForeignKey(
                        name: "FK_StudentsGroupDisciplines_Disciplines_DisciplinesId",
                        column: x => x.DisciplinesId,
                        principalTable: "Disciplines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentsGroupDisciplines_StudentsGroups_StudentsGroupsId",
                        column: x => x.StudentsGroupsId,
                        principalTable: "StudentsGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentsGroupStudents",
                columns: table => new
                {
                    StudentsGroupsId = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsGroupStudents", x => new { x.StudentsGroupsId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_StudentsGroupStudents_AspNetUsers_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentsGroupStudents_StudentsGroups_StudentsGroupsId",
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
                values: new object[] { "6a6dbb54-89dc-4a53-a9ee-18ca2399f3d8", "AQAAAAIAAYagAAAAELgisZIZhRdJVEBtkIcvA3+oBAQVJJKqC9eW8bf6VUNplzi7v1uK9+qrHhG/pUorpA==" });

            migrationBuilder.CreateIndex(
                name: "IX_StudentsGroupDisciplines_StudentsGroupsId",
                table: "StudentsGroupDisciplines",
                column: "StudentsGroupsId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsGroupStudents_StudentsId",
                table: "StudentsGroupStudents",
                column: "StudentsId");
        }
    }
}

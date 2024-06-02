using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityACS.API.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Group_GroupId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_StudentsGroups_StudentsGroupId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Disciplines_StudentsGroups_StudentsGroupId",
                table: "Disciplines");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Student_StudentId",
                table: "Reviews");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_StudentId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Disciplines_StudentsGroupId",
                table: "Disciplines");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_GroupId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_StudentsGroupId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StudentsGroupId",
                table: "Disciplines");

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
                values: new object[] { "004bc741-f3a8-479e-8a7f-b730cb85ce8e", "AQAAAAIAAYagAAAAECtWD+CWU6BFxYbS1akMVUid2TmOk6FqwL39LxdHLURX0iGJMjf/kPOUZHWXHTbDQA==" });

            migrationBuilder.CreateIndex(
                name: "IX_StudentsGroupDisciplines_StudentsGroupsId",
                table: "StudentsGroupDisciplines",
                column: "StudentsGroupsId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsGroupStudents_StudentsId",
                table: "StudentsGroupStudents",
                column: "StudentsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "StudentsGroupId",
                table: "Disciplines",
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

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Photo = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "GroupId", "PasswordHash", "StudentsGroupId" },
                values: new object[] { "d695b897-141c-4c0d-8d2b-fc35eb7357c3", null, "AQAAAAIAAYagAAAAEPKOcpadBCO+X/OMdD3nOTPjpVHgCTHuzgUA7HuDCH8YiFP2K7TukxQhMyqeKnuEaA==", null });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_StudentId",
                table: "Reviews",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_StudentsGroupId",
                table: "Disciplines",
                column: "StudentsGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_GroupId",
                table: "AspNetUsers",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_StudentsGroupId",
                table: "AspNetUsers",
                column: "StudentsGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_GroupId",
                table: "Student",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Group_GroupId",
                table: "AspNetUsers",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_StudentsGroups_StudentsGroupId",
                table: "AspNetUsers",
                column: "StudentsGroupId",
                principalTable: "StudentsGroups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplines_StudentsGroups_StudentsGroupId",
                table: "Disciplines",
                column: "StudentsGroupId",
                principalTable: "StudentsGroups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Student_StudentId",
                table: "Reviews",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

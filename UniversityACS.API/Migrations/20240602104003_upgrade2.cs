using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityACS.API.Migrations
{
    /// <inheritdoc />
    public partial class upgrade2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserGroup");

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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "GroupId", "PasswordHash" },
                values: new object[] { "6dfa5b9c-b7da-4223-a4e0-931a87ddd534", null, "AQAAAAIAAYagAAAAEI3HR9m8xv6Mx/a0xxddnKdQMPw0ydb/0TFIujK+eGgPsaH1JhFY9HiMiHO7zOCd5w==" });

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_StudentsGroupId",
                table: "Disciplines",
                column: "StudentsGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_GroupId",
                table: "AspNetUsers",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Group_GroupId",
                table: "AspNetUsers",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id");

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
                name: "FK_AspNetUsers_Group_GroupId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Disciplines_StudentsGroups_StudentsGroupId",
                table: "Disciplines");

            migrationBuilder.DropIndex(
                name: "IX_Disciplines_StudentsGroupId",
                table: "Disciplines");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_GroupId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StudentsGroupId",
                table: "Disciplines");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "ApplicationUserGroup",
                columns: table => new
                {
                    GroupsId = table.Column<Guid>(type: "uuid", nullable: false),
                    TeachersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserGroup", x => new { x.GroupsId, x.TeachersId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserGroup_AspNetUsers_TeachersId",
                        column: x => x.TeachersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserGroup_Group_GroupsId",
                        column: x => x.GroupsId,
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "50491bda-7e87-4bf1-8aec-b9cd745ff1c3", "AQAAAAIAAYagAAAAEFiLFjy/UT9K8CdKbRGGntPJMiWNK2x5mvYglC4zxHUJ1R5Mw0WO4acnTAL7EBiRvg==" });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserGroup_TeachersId",
                table: "ApplicationUserGroup",
                column: "TeachersId");
        }
    }
}

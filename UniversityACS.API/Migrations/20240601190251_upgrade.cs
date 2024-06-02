using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityACS.API.Migrations
{
    /// <inheritdoc />
    public partial class upgrade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserGroup_Groups_GroupsId",
                table: "ApplicationUserGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_Homeworks_Students_Id",
                table: "Homeworks");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Students_StudentId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAttendance_Lessons_LessonId",
                table: "StudentAttendance");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Groups_GroupId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Homeworks",
                table: "Homeworks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentAttendance",
                table: "StudentAttendance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Groups",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "TeacherName",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "Homeworks");

            migrationBuilder.DropColumn(
                name: "StudentName",
                table: "StudentAttendance");

            migrationBuilder.RenameTable(
                name: "Homeworks",
                newName: "HomeWorks");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "Student");

            migrationBuilder.RenameTable(
                name: "StudentAttendance",
                newName: "StudentAttendances");

            migrationBuilder.RenameTable(
                name: "Groups",
                newName: "Group");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "HomeWorks",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "IsCompleted",
                table: "HomeWorks",
                newName: "IsChecked");

            migrationBuilder.RenameIndex(
                name: "IX_Students_GroupId",
                table: "Student",
                newName: "IX_Student_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAttendance_LessonId",
                table: "StudentAttendances",
                newName: "IX_StudentAttendances_LessonId");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "TeacherTests",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SubjectName",
                table: "Lessons",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "LessonName",
                table: "Lessons",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<Guid>(
                name: "HomeWorkId",
                table: "Lessons",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "HomeWorks",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "Answer",
                table: "HomeWorks",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "HomeWorks",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DisciplineId",
                table: "HomeWorks",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "File",
                table: "HomeWorks",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Grade",
                table: "HomeWorks",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "StudentId",
                table: "HomeWorks",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TeacherId",
                table: "HomeWorks",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StudentsGroupId",
                table: "AspNetUsers",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsLate",
                table: "StudentAttendances",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "StudentId",
                table: "StudentAttendances",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_HomeWorks",
                table: "HomeWorks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student",
                table: "Student",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentAttendances",
                table: "StudentAttendances",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Group",
                table: "Group",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "StudentsGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsGroups", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "StudentsGroupId" },
                values: new object[] { "50491bda-7e87-4bf1-8aec-b9cd745ff1c3", "AQAAAAIAAYagAAAAEFiLFjy/UT9K8CdKbRGGntPJMiWNK2x5mvYglC4zxHUJ1R5Mw0WO4acnTAL7EBiRvg==", null });

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_HomeWorkId",
                table: "Lessons",
                column: "HomeWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_TeacherId",
                table: "Lessons",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeWorks_DisciplineId",
                table: "HomeWorks",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeWorks_StudentId",
                table: "HomeWorks",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeWorks_TeacherId",
                table: "HomeWorks",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_StudentsGroupId",
                table: "AspNetUsers",
                column: "StudentsGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAttendances_StudentId",
                table: "StudentAttendances",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserGroup_Group_GroupsId",
                table: "ApplicationUserGroup",
                column: "GroupsId",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_StudentsGroups_StudentsGroupId",
                table: "AspNetUsers",
                column: "StudentsGroupId",
                principalTable: "StudentsGroups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HomeWorks_AspNetUsers_StudentId",
                table: "HomeWorks",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HomeWorks_AspNetUsers_TeacherId",
                table: "HomeWorks",
                column: "TeacherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HomeWorks_Disciplines_DisciplineId",
                table: "HomeWorks",
                column: "DisciplineId",
                principalTable: "Disciplines",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_AspNetUsers_TeacherId",
                table: "Lessons",
                column: "TeacherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_HomeWorks_HomeWorkId",
                table: "Lessons",
                column: "HomeWorkId",
                principalTable: "HomeWorks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Student_StudentId",
                table: "Reviews",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Group_GroupId",
                table: "Student",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAttendances_AspNetUsers_StudentId",
                table: "StudentAttendances",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAttendances_Lessons_LessonId",
                table: "StudentAttendances",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserGroup_Group_GroupsId",
                table: "ApplicationUserGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_StudentsGroups_StudentsGroupId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeWorks_AspNetUsers_StudentId",
                table: "HomeWorks");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeWorks_AspNetUsers_TeacherId",
                table: "HomeWorks");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeWorks_Disciplines_DisciplineId",
                table: "HomeWorks");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_AspNetUsers_TeacherId",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_HomeWorks_HomeWorkId",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Student_StudentId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Group_GroupId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAttendances_AspNetUsers_StudentId",
                table: "StudentAttendances");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAttendances_Lessons_LessonId",
                table: "StudentAttendances");

            migrationBuilder.DropTable(
                name: "StudentsGroups");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_HomeWorkId",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_TeacherId",
                table: "Lessons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HomeWorks",
                table: "HomeWorks");

            migrationBuilder.DropIndex(
                name: "IX_HomeWorks_DisciplineId",
                table: "HomeWorks");

            migrationBuilder.DropIndex(
                name: "IX_HomeWorks_StudentId",
                table: "HomeWorks");

            migrationBuilder.DropIndex(
                name: "IX_HomeWorks_TeacherId",
                table: "HomeWorks");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_StudentsGroupId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentAttendances",
                table: "StudentAttendances");

            migrationBuilder.DropIndex(
                name: "IX_StudentAttendances_StudentId",
                table: "StudentAttendances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Student",
                table: "Student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Group",
                table: "Group");

            migrationBuilder.DropColumn(
                name: "HomeWorkId",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "Answer",
                table: "HomeWorks");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "HomeWorks");

            migrationBuilder.DropColumn(
                name: "DisciplineId",
                table: "HomeWorks");

            migrationBuilder.DropColumn(
                name: "File",
                table: "HomeWorks");

            migrationBuilder.DropColumn(
                name: "Grade",
                table: "HomeWorks");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "HomeWorks");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "HomeWorks");

            migrationBuilder.DropColumn(
                name: "StudentsGroupId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsLate",
                table: "StudentAttendances");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "StudentAttendances");

            migrationBuilder.RenameTable(
                name: "HomeWorks",
                newName: "Homeworks");

            migrationBuilder.RenameTable(
                name: "StudentAttendances",
                newName: "StudentAttendance");

            migrationBuilder.RenameTable(
                name: "Student",
                newName: "Students");

            migrationBuilder.RenameTable(
                name: "Group",
                newName: "Groups");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Homeworks",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "IsChecked",
                table: "Homeworks",
                newName: "IsCompleted");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAttendances_LessonId",
                table: "StudentAttendance",
                newName: "IX_StudentAttendance_LessonId");

            migrationBuilder.RenameIndex(
                name: "IX_Student_GroupId",
                table: "Students",
                newName: "IX_Students_GroupId");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "TeacherTests",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "SubjectName",
                table: "Lessons",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LessonName",
                table: "Lessons",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeacherName",
                table: "Lessons",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Homeworks",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "Homeworks",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "StudentName",
                table: "StudentAttendance",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Homeworks",
                table: "Homeworks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentAttendance",
                table: "StudentAttendance",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Groups",
                table: "Groups",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "dc8991ab-d191-4224-9c16-a55b379efc3c", "AQAAAAIAAYagAAAAEK51q+WB93FLQiEpkBJhHpOQh1wtpqjYXnMBoDfS9++JyDlRyHTU8H9+FKuE+MpUmg==" });

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserGroup_Groups_GroupsId",
                table: "ApplicationUserGroup",
                column: "GroupsId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Homeworks_Students_Id",
                table: "Homeworks",
                column: "Id",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Students_StudentId",
                table: "Reviews",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAttendance_Lessons_LessonId",
                table: "StudentAttendance",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Groups_GroupId",
                table: "Students",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

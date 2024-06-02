using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityACS.API.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6a6dbb54-89dc-4a53-a9ee-18ca2399f3d8", "AQAAAAIAAYagAAAAELgisZIZhRdJVEBtkIcvA3+oBAQVJJKqC9eW8bf6VUNplzi7v1uK9+qrHhG/pUorpA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "004bc741-f3a8-479e-8a7f-b730cb85ce8e", "AQAAAAIAAYagAAAAECtWD+CWU6BFxYbS1akMVUid2TmOk6FqwL39LxdHLURX0iGJMjf/kPOUZHWXHTbDQA==" });
        }
    }
}

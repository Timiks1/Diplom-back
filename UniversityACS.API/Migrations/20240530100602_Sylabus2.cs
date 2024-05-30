using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityACS.API.Migrations
{
    /// <inheritdoc />
    public partial class Sylabus2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "80300e2d-75bc-4c35-9b8c-1e7b4e36f20e", "AQAAAAIAAYagAAAAEGMx1yce38O0fEYU4mxg8hwX0osSXLTAMGE/bHPXGVDOp0A8jqoCLf8WgX0XewVyxQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ebf7ff32-509f-4705-9969-b22bafa867a1", "AQAAAAIAAYagAAAAENitMHkWso8ZrCgux5/z8V4+TxfqIFpVlZyPemxo8TvEXlHEMRjrfz+RzgM/GIpZlw==" });
        }
    }
}

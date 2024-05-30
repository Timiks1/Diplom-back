using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityACS.API.Migrations
{
    /// <inheritdoc />
    public partial class Sylabus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ebf7ff32-509f-4705-9969-b22bafa867a1", "AQAAAAIAAYagAAAAENitMHkWso8ZrCgux5/z8V4+TxfqIFpVlZyPemxo8TvEXlHEMRjrfz+RzgM/GIpZlw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4cf5a270-355a-4ab5-8379-a8a880fb3b06", "AQAAAAIAAYagAAAAEJg296Pj/U/+C18P1tFouJCWdTo59asvpPqBjc9gLvsappqZh6GoWuI93aGtJ0EEqQ==" });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityACS.API.Migrations
{
    /// <inheritdoc />
    public partial class moreUserInfo7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "academic_certificate",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "academic_leave_reasons",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "birth_date",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "category_code",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "citizenship",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "document_number",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "document_series",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "dpo_type",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "education_document",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "education_level",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "educational_program",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "enrollment_info",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "enrollment_order",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "entry_basis",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "entry_score",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "expulsion_reason",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "fo_id",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "funding_source",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "gender",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "group",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "id_card",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "issue_date",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "issued_diploma",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "last_modified_time",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "name_in_english",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "op_id",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "previous_education_info",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "previous_specialty",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "shortened_study_period",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "specialization",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "specialty",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "status_since",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "student",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "student_card",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "study_end",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "study_form",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "study_start",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "study_status",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tax_number",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "valid_until",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "withdrawal_certificate",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "academic_certificate", "academic_leave_reasons", "birth_date", "category_code", "citizenship", "document_number", "document_series", "dpo_type", "education_document", "education_level", "educational_program", "enrollment_info", "enrollment_order", "entry_basis", "entry_score", "expulsion_reason", "fo_id", "funding_source", "gender", "group", "id_card", "issue_date", "issued_diploma", "last_modified_time", "name_in_english", "op_id", "previous_education_info", "previous_specialty", "shortened_study_period", "specialization", "specialty", "status_since", "student", "student_card", "study_end", "study_form", "study_start", "study_status", "tax_number", "valid_until", "withdrawal_certificate" },
                values: new object[] { "162adc90-7d81-4038-bc4a-6d39cad11dda", "AQAAAAIAAYagAAAAECxiPQYtQMetXmfJ6CTmzKNzwohiPXp1ClpLv/4uil39+tsiUits4KmRDHHJW4zDtA==", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "academic_certificate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "academic_leave_reasons",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "birth_date",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "category_code",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "citizenship",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "document_number",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "document_series",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "dpo_type",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "education_document",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "education_level",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "educational_program",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "enrollment_info",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "enrollment_order",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "entry_basis",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "entry_score",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "expulsion_reason",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "fo_id",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "funding_source",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "gender",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "group",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "id_card",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "issue_date",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "issued_diploma",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "last_modified_time",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "name_in_english",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "op_id",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "previous_education_info",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "previous_specialty",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "shortened_study_period",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "specialization",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "specialty",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "status_since",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "student",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "student_card",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "study_end",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "study_form",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "study_start",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "study_status",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "tax_number",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "valid_until",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "withdrawal_certificate",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cedbba79-5a91-469c-a14c-34df4a15d2c9", "AQAAAAIAAYagAAAAEAq9DIoUrKpToKmscd7hXIwE5nA2Y7lVKhAlHN7SYEvwH3z46iis2/6Vc64M/yKt+A==" });
        }
    }
}

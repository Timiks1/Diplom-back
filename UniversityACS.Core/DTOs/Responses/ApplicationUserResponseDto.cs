﻿namespace UniversityACS.Core.DTOs.Responses;

public class ApplicationUserResponseDto
{
    public Guid Id { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? DepartmentEmail { get; set; }
    public string? Patronymic { get; set; }

    public string? PhoneNumber { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? DepartmentName { get; set; }
    public string? GroupName { get; set; }
    public Guid? DepartmentId { get; set; }
    public Guid? GroupId { get; set; }
    public string? PhotoBase64 { get; set; } // Здесь фото в виде строки Base64
    public string? UnHiddenPassword { get; set; }
    public int? Age { get; set; }
    public string? Course { get; set; }
    public string? EducationTime { get; set; }
    public string? id_card { get; set; }
    public string? status_since { get; set; }
    public string? study_status { get; set; }
    public string? fo_id { get; set; }
    public string? student { get; set; }
    public string? birth_date { get; set; }
    public string? dpo_type { get; set; }
    public string? document_series { get; set; }
    public string? document_number { get; set; }
    public string? issue_date { get; set; }
    public string? valid_until { get; set; }
    public string? gender { get; set; }
    public string? citizenship { get; set; }
    public string? name_in_english { get; set; }
    public string? tax_number { get; set; }
    public string? study_start { get; set; }
    public string? study_end { get; set; }
    public string? education_level { get; set; }
    public string? entry_basis { get; set; }
    public string? study_form { get; set; }
    public string? funding_source { get; set; }
    public string? previous_specialty { get; set; }
    public string? shortened_study_period { get; set; }
    public string? specialty { get; set; }
    public string? specialization { get; set; }
    public string? op_id { get; set; }
    public string? educational_program { get; set; }
    public string? group { get; set; }
    public string? category_code { get; set; }
    public string? expulsion_reason { get; set; }
    public string? academic_leave_reasons { get; set; }
    public string? enrollment_order { get; set; }
    public string? education_document { get; set; }
    public string? previous_education_info { get; set; }
    public string? academic_certificate { get; set; }
    public string? withdrawal_certificate { get; set; }
    public string? student_card { get; set; }
    public string? issued_diploma { get; set; }
    public string? enrollment_info { get; set; }
    public string? entry_score { get; set; }
    public string? last_modified_time { get; set; }
}
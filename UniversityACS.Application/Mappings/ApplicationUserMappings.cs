using DocumentFormat.OpenXml.Vml.Office;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;
using UniversityACS.Core.Entities;

namespace UniversityACS.Application.Mappings;

public static class ApplicationUserMappings
{
    public static ApplicationUser ToEntity(this ApplicationUserDto dto)
    {
        return new ApplicationUser
        {
            UserName = dto.UserName,
            Email = dto.Email,
            DepartmentEmail = dto.DepartmentEmail,
            Patronymic = dto.Patronymic,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            DepartmentId = dto.DepartmentId,
            PhoneNumber = dto.PhoneNumber,
            ConcurrencyStamp = Guid.NewGuid().ToString(),
            SecurityStamp = Guid.NewGuid().ToString(),
            Photo = dto.Photo,
            UnHiddenPassword = dto.UnHiddenPassword,
            Age = dto.Age,
            Course = dto.Course,
            EducationTime = dto.EducationTime,
            id_card = dto.id_card,
            status_since = dto.status_since,
            study_status = dto.study_status,
            fo_id = dto.fo_id,
            student = dto.student,
            birth_date = dto.birth_date,
            dpo_type = dto.dpo_type,
            document_series = dto.document_series,
            document_number = dto.document_number,
            issue_date = dto.issue_date,
            valid_until = dto.valid_until,
            gender = dto.gender,
            citizenship = dto.citizenship,
            name_in_english = dto.name_in_english,
            tax_number = dto.tax_number,
            study_start = dto.study_start,
            study_end = dto.study_end,
            education_level = dto.education_level,
            entry_basis = dto.entry_basis,
            study_form = dto.study_form,
            funding_source = dto.funding_source,
            previous_specialty = dto.previous_specialty,
            shortened_study_period = dto.shortened_study_period,
            specialty = dto.specialty,
            specialization = dto.specialization,
            op_id = dto.op_id,
            educational_program = dto.educational_program,
            group = dto.group,
            category_code = dto.category_code,
            expulsion_reason = dto.expulsion_reason,
            academic_leave_reasons = dto.academic_leave_reasons,
            enrollment_order = dto.enrollment_order,
            education_document = dto.education_document,
            previous_education_info = dto.previous_education_info,
            academic_certificate = dto.academic_certificate,
            withdrawal_certificate = dto.withdrawal_certificate,
            student_card = dto.student_card,
            issued_diploma = dto.issued_diploma,
            enrollment_info = dto.enrollment_info,
            entry_score = dto.entry_score,
            last_modified_time = dto.last_modified_time

        };
    }

    public static void UpdateEntity(this ApplicationUser user, ApplicationUserDto dto)
    {
        user.UserName = dto.UserName;
        user.Email = dto.Email;
        user.DepartmentEmail = dto.DepartmentEmail;
        user.Patronymic = dto.Patronymic;
        user.FirstName = dto.FirstName;
        user.LastName = dto.LastName;
        user.DepartmentId = dto.DepartmentId;
        user.PhoneNumber = dto.PhoneNumber;
        user.Photo = dto.Photo;
        user.UnHiddenPassword = dto.UnHiddenPassword;
        user.Age = dto.Age;
        user.Course = dto.Course;
        user.EducationTime = dto.EducationTime;
        user.id_card = dto.id_card;
        user.status_since = dto.status_since;
        user.study_status = dto.study_status;
        user.fo_id = dto.fo_id;
        user.student = dto.student;
        user.birth_date = dto.birth_date;
        user.dpo_type = dto.dpo_type;
        user.document_series = dto.document_series;
        user.document_number = dto.document_number;
        user.issue_date = dto.issue_date;
        user.valid_until = dto.valid_until;
        user.gender = dto.gender;
        user.citizenship = dto.citizenship;
        user.name_in_english = dto.name_in_english;
        user.tax_number = dto.tax_number;
        user.study_start = dto.study_start;
        user.study_end = dto.study_end;
        user.education_level = dto.education_level;
        user.entry_basis = dto.entry_basis;
        user.study_form = dto.study_form;
        user.funding_source = dto.funding_source;
        user.previous_specialty = dto.previous_specialty;
        user.shortened_study_period = dto.shortened_study_period;
        user.specialty = dto.specialty;
        user.specialization = dto.specialization;
        user.op_id = dto.op_id;
        user.educational_program = dto.educational_program;
        user.group = dto.group;
        user.category_code = dto.category_code;
        user.expulsion_reason = dto.expulsion_reason;
        user.academic_leave_reasons = dto.academic_leave_reasons;
        user.enrollment_order = dto.enrollment_order;
        user.education_document = dto.education_document;
        user.previous_education_info = dto.previous_education_info;
        user.academic_certificate = dto.academic_certificate;
        user.withdrawal_certificate = dto.withdrawal_certificate;
        user.student_card = dto.student_card;
        user.issued_diploma = dto.issued_diploma;
        user.enrollment_info = dto.enrollment_info;
        user.entry_score = dto.entry_score;
        user.last_modified_time = dto.last_modified_time;
    }

    public static ApplicationUserResponseDto ToDto(this ApplicationUser user)
    {
        return new ApplicationUserResponseDto
        {
            Id = user.Id,
            UserName = user.UserName,
            Email = user.Email,
            DepartmentEmail = user.DepartmentEmail,
            Patronymic = user.Patronymic,

            FirstName = user.FirstName,
            LastName = user.LastName,
            DepartmentId = user.DepartmentId,
            PhoneNumber = user.PhoneNumber,
            DepartmentName = user.Department?.Name,
            PhotoBase64 = user.Photo != null ? Convert.ToBase64String(user.Photo) : null,

            UnHiddenPassword = user.UnHiddenPassword,
            Age = user.Age,
            Course = user.Course,
            EducationTime = user.EducationTime,
            id_card = user.id_card,
            status_since = user.status_since,
            study_status = user.study_status,
            fo_id = user.fo_id,
            student = user.student,
            birth_date = user.birth_date,
            dpo_type = user.dpo_type,
            document_series = user.document_series,
            document_number = user.document_number,
            issue_date = user.issue_date,
            valid_until = user.valid_until,
            gender = user.gender,
            citizenship = user.citizenship,
            name_in_english = user.name_in_english,
            tax_number = user.tax_number,
            study_start = user.study_start,
            study_end = user.study_end,
            education_level = user.education_level,
            entry_basis = user.entry_basis,
            study_form = user.study_form,
            funding_source = user.funding_source,
            previous_specialty = user.previous_specialty,
            shortened_study_period = user.shortened_study_period,
            specialty = user.specialty,
            specialization = user.specialization,
            op_id = user.op_id,
            educational_program = user.educational_program,
            group = user.group,
            category_code = user.category_code,
            expulsion_reason = user.expulsion_reason,
            academic_leave_reasons = user.academic_leave_reasons,
            enrollment_order = user.enrollment_order,
            education_document = user.education_document,
            previous_education_info = user.previous_education_info,
            academic_certificate = user.academic_certificate,
            withdrawal_certificate = user.withdrawal_certificate,
            student_card = user.student_card,
            issued_diploma = user.issued_diploma,
            enrollment_info = user.enrollment_info,
            entry_score = user.entry_score,
            last_modified_time = user.last_modified_time

        };
    }
}
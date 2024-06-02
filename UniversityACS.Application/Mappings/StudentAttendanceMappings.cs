using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.Entities;

namespace UniversityACS.Application.Mappings;

public static class StudentAttendanceMappings
{
    public static StudentAttendance ToEntity(this StudentAttendanceDto dto)
    {
        return new StudentAttendance
        {
            Id = dto.Id,
            StudentId = dto.StudentId,
            IsPresent = dto.IsPresent,
            IsLate = dto.IsLate,
            Grade = dto.Grade,
            LessonId = dto.LessonId
        };
    }

    public static void UpdateEntity(this StudentAttendance entity, StudentAttendanceDto dto)
    {
        entity.IsPresent = dto.IsPresent;
        entity.IsLate = dto.IsLate;
        entity.Grade = dto.Grade;
        entity.LessonId = dto.LessonId;
    }

    public static StudentAttendanceDto ToDto(this StudentAttendance entity)
    {
        return new StudentAttendanceDto
        {
            Id = entity.Id,
            StudentId = entity.StudentId,
            IsPresent = entity.IsPresent,
            IsLate = entity.IsLate,
            Grade = entity.Grade,
            LessonId = entity.LessonId
        };
    }
}
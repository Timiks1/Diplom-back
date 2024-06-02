using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.Entities;

namespace UniversityACS.Application.Mappings;

public static class LessonMappings
{
    public static Lesson ToEntity(this LessonDto dto)
    {
        return new Lesson
        {
            Id = dto.Id,
            Date = dto.Date,
            SubjectName = dto.SubjectName,
            LessonName = dto.LessonName,
            TeacherId = dto.TeacherId,
            HomeWorkId = dto.HomeWorkId,
            StudentAttendances = dto.StudentAttendances?.Select(sa => sa.ToEntity()).ToList()
        };
    }

    public static void UpdateEntity(this Lesson entity, LessonDto dto)
    {
        entity.Date = dto.Date;
        entity.SubjectName = dto.SubjectName;
        entity.LessonName = dto.LessonName;
        entity.TeacherId = dto.TeacherId;
        entity.HomeWorkId = dto.HomeWorkId;
        entity.StudentAttendances = dto.StudentAttendances?.Select(sa => sa.ToEntity()).ToList();
    }

    public static LessonDto ToDto(this Lesson entity)
    {
        return new LessonDto
        {
            Id = entity.Id,
            Date = entity.Date,
            SubjectName = entity.SubjectName,
            LessonName = entity.LessonName,
            TeacherId = entity.TeacherId,
            HomeWorkId = entity.HomeWorkId,
            StudentAttendances = entity.StudentAttendances?.Select(sa => sa.ToDto()).ToList()
        };
    }
}
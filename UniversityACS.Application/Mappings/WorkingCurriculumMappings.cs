using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;
using UniversityACS.Core.Entities;

namespace UniversityACS.Application.Mappings;

public static class WorkingCurriculumMappings
{
    public static WorkingCurriculum ToEntity(this WorkingCurriculumDto dto)
    {
        return new WorkingCurriculum
        {
            Id = dto.Id,
            TeacherId = dto.TeacherId,
            Name = dto.Name,
            LessonId = dto.LessonId, // новое поле
            FileFormat = dto.FileFormat // новое поле
        };
    }

    public static void UpdateEntity(this WorkingCurriculum entity, WorkingCurriculumDto dto)
    {
        entity.LessonId = dto.LessonId; // обновление нового поля
        entity.FileFormat = dto.FileFormat; // обновление нового поля
        if (dto.File != null)
        {
            using (var memoryStream = new MemoryStream())
            {
                dto.File.CopyTo(memoryStream);
                entity.File = memoryStream.ToArray();
            }
        }

    }

    public static WorkingCurriculumResponseDto ToDto(this WorkingCurriculum entity)
    {
        return new WorkingCurriculumResponseDto
        {
            Id = entity.Id,
            TeacherId = entity.TeacherId,
            TeacherUserName = entity.Teacher?.UserName,
            Name = entity.Name,
            File = entity.File,
            LessonId = entity.LessonId, // новое поле
            FileFormat = entity.FileFormat // новое поле

        };
    }
}
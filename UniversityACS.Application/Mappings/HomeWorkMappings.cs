using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;
using UniversityACS.Core.Entities;

namespace UniversityACS.Application.Mappings;

public static class HomeWorkMappings
{
    public static HomeWork ToEntity(this HomeWorkDto dto)
    {
        return new HomeWork
        {
            Id = dto.Id,
            Name = dto.Name,
            Description = dto.Description,
            Comment = dto.Comment,
            Answer = dto.Answer,
            IsChecked = dto.IsChecked,
            Grade = dto.Grade,
            StudentId = dto.StudentId,
            TeacherId = dto.TeacherId,
            DisciplineId = dto.DisciplineId
        };
    }

    public static void UpdateEntity(this HomeWork entity, HomeWorkDto dto)
    {
        entity.Name = dto.Name;
        entity.Description = dto.Description;
        entity.Comment = dto.Comment;
        entity.Answer = dto.Answer;
        entity.IsChecked = dto.IsChecked;
        entity.Grade = dto.Grade;
        entity.StudentId = dto.StudentId;
        entity.TeacherId = dto.TeacherId;
        entity.DisciplineId = dto.DisciplineId;
    }

    public static HomeWorkResponseDto ToDto(this HomeWork entity)
    {
        return new HomeWorkResponseDto
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            Comment = entity.Comment,
            Answer = entity.Answer,
            File = entity.File,
            IsChecked = entity.IsChecked,
            Grade = entity.Grade,
            StudentId = entity.StudentId,
            TeacherId = entity.TeacherId,
            DisciplineId = entity.DisciplineId,
            DisciplineName = entity.Discipline?.Name,
            StudentName = entity.Student?.FirstName + " " + entity.Student?.LastName,
            TeacherName = entity.Teacher?.FirstName + " " + entity.Teacher?.LastName
        };
    }
}
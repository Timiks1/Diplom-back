using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;
using UniversityACS.Core.Entities;

namespace UniversityACS.Application.Mappings;

public static class DisciplineMappings
{
    public static Discipline ToEntity(this DisciplineDto dto)
    {
        return new Discipline()
        {
            Id = dto.Id,
            Description = dto.Description,
            Name = dto.Name,
            Courses = dto.Courses,
            FieldOfStudy = dto.FieldOfStudy
        };
    }

    public static void UpdateEntity(this Discipline discipline, DisciplineDto dto)
    {
        discipline.Description = dto.Description;
        discipline.Name = dto.Name;
        discipline.Courses = dto.Courses;
        discipline.FieldOfStudy = dto.FieldOfStudy;
    }

    public static DisciplineDto ToDto(this Discipline discipline)
    {
        return new DisciplineDto()
        {
            Id = discipline.Id,
            Description = discipline.Description,
            Name = discipline.Name,
            Courses = discipline.Courses,
            FieldOfStudy = discipline.FieldOfStudy
        };
    }

}
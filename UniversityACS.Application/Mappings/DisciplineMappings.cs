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
            FieldOfStudy = dto.FieldOfStudy,
            LaboratoryHours = dto.LaboratoryHours,
            PracticHours = dto.PracticHours,
            LecturerHours = dto.LecturerHours,
            ECTS = dto.ECTS,
            AuditoryTasks = dto.AuditoryTasks,
            Exams = dto.Exams,
            Tests = dto.Tests,
            IndependentHours = dto.IndependentHours,
        };
    }

    public static void UpdateEntity(this Discipline discipline, DisciplineDto dto)
    {
        discipline.Description = dto.Description;
        discipline.Name = dto.Name;
        discipline.Courses = dto.Courses;
        discipline.FieldOfStudy = dto.FieldOfStudy;
        discipline.LaboratoryHours = dto.LaboratoryHours;
        discipline.PracticHours = dto.PracticHours;
        discipline.LecturerHours = dto.LecturerHours;
        discipline.ECTS = dto.ECTS;
        discipline.AuditoryTasks = dto.AuditoryTasks;
        discipline.Exams = dto.Exams;
        discipline.Tests = dto.Tests;
        discipline.IndependentHours = dto.IndependentHours;
    }

    public static DisciplineDto ToDto(this Discipline discipline)
    {
        return new DisciplineDto()
        {
            Id = discipline.Id,
            Description = discipline.Description,
            Name = discipline.Name,
            Courses = discipline.Courses,
            FieldOfStudy = discipline.FieldOfStudy,
            LaboratoryHours = discipline.LaboratoryHours,
            PracticHours = discipline.PracticHours,
            LecturerHours = discipline.LecturerHours,
            ECTS = discipline.ECTS,
            AuditoryTasks = discipline.AuditoryTasks,
            Exams = discipline.Exams,
            Tests = discipline.Tests,
            IndependentHours = discipline.IndependentHours,
        };
    }

}
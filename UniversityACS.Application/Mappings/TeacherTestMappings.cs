using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.Entities;

namespace UniversityACS.Application.Mappings;

public static class TeacherTestMappings
{
    public static TeacherTest ToEntity(this TeacherTestDto dto)
    {
        return new TeacherTest
        {
            Id = dto.Id,
            TeacherId = dto.TeacherId,
            Status = dto.Status,
            TestTheme = dto.TestTheme,
            TestUrl = dto.TestUrl,
            DisciplineId = dto.DisciplineId

        };
    }

    public static void UpdateEntity(this TeacherTest entity, TeacherTestDto dto)
    {
        entity.TeacherId = dto.TeacherId;
        entity.Status = dto.Status;
        entity.TestTheme = dto.TestTheme;
        entity.TestUrl = dto.TestUrl;
        entity.DisciplineId = dto.DisciplineId;

    }

    public static TeacherTestDto ToDto(this TeacherTest entity)
    {
        return new TeacherTestDto
        {
            Id = entity.Id,
            TeacherId = entity.TeacherId,
            Status = entity.Status,
            TestTheme = entity.TestTheme,
            TestUrl = entity.TestUrl,
            DisciplineId = entity.DisciplineId,

        };
    }
}

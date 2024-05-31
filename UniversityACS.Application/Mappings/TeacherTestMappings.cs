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
            Status = dto.Status, // Добавляем маппинг статуса
            TestTheme = dto.TestTheme,
            TestUrl = dto.TestUrl
        };
    }

    public static void UpdateEntity(this TeacherTest entity, TeacherTestDto dto)
    {
        entity.TeacherId = dto.TeacherId;
        entity.Status = dto.Status; // Обновляем статус
        entity.TestTheme = dto.TestTheme;
        entity.TestUrl = dto.TestUrl;
    }

    public static TeacherTestDto ToDto(this TeacherTest entity)
    {
        return new TeacherTestDto
        {
            Id = entity.Id,
            TeacherId = entity.TeacherId,
            Status = entity.Status, // Добавляем маппинг статуса
            TestTheme = entity.TestTheme,
            TestUrl = entity.TestUrl
        };
    }
}

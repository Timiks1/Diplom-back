using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;
using UniversityACS.Core.Entities;

namespace UniversityACS.Application.Mappings;

public static class StudentsGroupMappings
{
    public static StudentsGroup ToEntity(this StudentsGroupDto dto)
    {
        return new StudentsGroup()
        {
            Id = dto.Id,
            Name = dto.Name,
            Description = dto.Description
        };
    }

    public static void UpdateEntity(this StudentsGroup entity, StudentsGroupDto dto)
    {
        entity.Name = dto.Name;
        entity.Description = dto.Description;
    }

    public static StudentsGroupResponseDto ToDto(this StudentsGroup entity)
    {
        return new StudentsGroupResponseDto()
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            Students = entity.Students?.Select(s => s.ToDto()).ToList()
        };
    }
}
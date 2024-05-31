using Microsoft.EntityFrameworkCore;
using UniversityACS.Application.Mappings;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Data.DataContext;

namespace UniversityACS.Application.Services.TeacherTestServices;

public class TeacherTestService : ITeacherTestService
{
    private readonly ApplicationDbContext _context;

    public TeacherTestService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CreateResponseDto<TeacherTestDto>> CreateAsync(TeacherTestDto dto, CancellationToken cancellationToken)
    {
        var entity = dto.ToEntity();


        await _context.TeacherTests.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new CreateResponseDto<TeacherTestDto>()
        {
            Success = true,
            Id = entity.Id
        };
    }

    public async Task<UpdateResponseDto<TeacherTestDto>> UpdateAsync(Guid id, TeacherTestDto dto, CancellationToken cancellationToken)
    {
        var existingEntity = await _context.TeacherTests
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (existingEntity == null)
        {
            return new UpdateResponseDto<TeacherTestDto>()
            {
                Success = false,
                ErrorMessage = "TeacherTest not found"
            };
        }

        // Обновляем значения полей сущности
        existingEntity.TeacherId = dto.TeacherId;
        existingEntity.Status = dto.Status;
        existingEntity.TestTheme = dto.TestTheme;
        existingEntity.TestUrl = dto.TestUrl;

        _context.TeacherTests.Update(existingEntity);
        await _context.SaveChangesAsync(cancellationToken);

        return new UpdateResponseDto<TeacherTestDto>() { Success = true, Id = existingEntity.Id };
    }


    public async Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var existingEntity = await _context.TeacherTests
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (existingEntity == null)
        {
            return new ResponseDto()
            {
                Success = false,
                ErrorMessage = "TeacherTest not found"
            };
        }

        _context.TeacherTests.Remove(existingEntity);
        await _context.SaveChangesAsync(cancellationToken);

        return new ResponseDto() { Success = true };
    }

    public async Task<DetailsResponseDto<TeacherTestDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var existingEntity = await _context.TeacherTests
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (existingEntity == null)
        {
            return new DetailsResponseDto<TeacherTestDto>()
            {
                Success = false,
                ErrorMessage = "TeacherTest not found"
            };
        }

        return new DetailsResponseDto<TeacherTestDto>()
        {
            Item = existingEntity.ToDto(),
            Success = true
        };
    }

    public async Task<ListResponseDto<TeacherTestDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var entities = await _context.TeacherTests
            .ToListAsync(cancellationToken);

        return new ListResponseDto<TeacherTestDto>()
        {
            Success = true,
            Items = entities.Select(x => x.ToDto()).ToList(),
            TotalCount = entities.Count
        };
    }

    public async Task<ListResponseDto<TeacherTestDto>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        var entities = await _context.TeacherTests
            .Where(x => x.TeacherId == userId)
            .ToListAsync(cancellationToken);

        return new ListResponseDto<TeacherTestDto>()
        {
            Success = true,
            Items = entities.Select(x => x.ToDto()).ToList(),
            TotalCount = entities.Count
        };
    }
}
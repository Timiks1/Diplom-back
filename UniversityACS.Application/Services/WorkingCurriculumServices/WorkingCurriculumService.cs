using Microsoft.EntityFrameworkCore;
using UniversityACS.Application.Mappings;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;
using UniversityACS.Data.DataContext;

namespace UniversityACS.Application.Services.WorkingCurriculumServices;

public class WorkingCurriculumService : IWorkingCurriculumService
{
    private readonly ApplicationDbContext _context;

    public WorkingCurriculumService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CreateResponseDto<WorkingCurriculumDto>> CreateAsync(WorkingCurriculumDto dto, CancellationToken cancellationToken)
    {
        var entity = dto.ToEntity();

        if (dto.File != null)
        {
            using var memoryStream = new MemoryStream();
            await dto.File.CopyToAsync(memoryStream, cancellationToken);
            entity.File = memoryStream.ToArray();
        }

        await _context.WorkingCurricula.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new CreateResponseDto<WorkingCurriculumDto>()
        {
            Success = true,
            Id = entity.Id
        };
    }

    public async Task<UpdateResponseDto<WorkingCurriculumDto>> UpdateAsync(Guid id, WorkingCurriculumDto dto, CancellationToken cancellationToken)
    {
        var existingEntity = await _context.WorkingCurricula
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (existingEntity == null)
        {
            return new UpdateResponseDto<WorkingCurriculumDto>()
            {
                Success = false,
                ErrorMessage = "WorkingCurriculum not found"
            };
        }

        existingEntity.UpdateEntity(dto);
        if (dto.File != null)
        {
            using var memoryStream = new MemoryStream();
            await dto.File.CopyToAsync(memoryStream, cancellationToken);
            existingEntity.File = memoryStream.ToArray();
        }

        _context.WorkingCurricula.Update(existingEntity);
        await _context.SaveChangesAsync(cancellationToken);

        return new UpdateResponseDto<WorkingCurriculumDto>() { Success = true, Id = existingEntity.Id };
    }

    public async Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var existingEntity = await _context.WorkingCurricula
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (existingEntity == null)
        {
            return new ResponseDto()
            {
                Success = false,
                ErrorMessage = "WorkingCurriculum not found"
            };
        }

        _context.WorkingCurricula.Remove(existingEntity);
        await _context.SaveChangesAsync(cancellationToken);

        return new ResponseDto() { Success = true };
    }

    public async Task<DetailsResponseDto<WorkingCurriculumResponseDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var existingEntity = await _context.WorkingCurricula
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (existingEntity == null)
        {
            return new DetailsResponseDto<WorkingCurriculumResponseDto>()
            {
                Success = false,
                ErrorMessage = "WorkingCurriculum not found"
            };
        }

        return new DetailsResponseDto<WorkingCurriculumResponseDto>()
        {
            Item = existingEntity.ToDto(),
            Success = true
        };
    }

    public async Task<ListResponseDto<WorkingCurriculumResponseDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var entities = await _context.WorkingCurricula
            .ToListAsync(cancellationToken);

        return new ListResponseDto<WorkingCurriculumResponseDto>()
        {
            Success = true,
            Items = entities.Select(x => x.ToDto()).ToList(),
            TotalCount = entities.Count
        };
    }

    public async Task<ListResponseDto<WorkingCurriculumResponseDto>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        var entities = await _context.WorkingCurricula
            .Where(x => x.TeacherId == userId)
            .ToListAsync(cancellationToken);

        return new ListResponseDto<WorkingCurriculumResponseDto>()
        {
            Success = true,
            Items = entities.Select(x => x.ToDto()).ToList(),
            TotalCount = entities.Count
        };
    }
    public async Task<ListResponseDto<WorkingCurriculumResponseDto>> GetByLessonIdAsync(Guid lessonId, CancellationToken cancellationToken)
    {
        var entities = await _context.WorkingCurricula
            .Where(x => x.LessonId == lessonId)
            .ToListAsync(cancellationToken);

        return new ListResponseDto<WorkingCurriculumResponseDto>()
        {
            Success = true,
            Items = entities.Select(x => x.ToDto()).ToList(),
            TotalCount = entities.Count
        };
    }
}
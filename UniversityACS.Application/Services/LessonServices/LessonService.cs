using Microsoft.EntityFrameworkCore;
using UniversityACS.Application.Mappings;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.Entities;
using UniversityACS.Data.DataContext;

namespace UniversityACS.Application.Services.LessonServices;

public class LessonService : ILessonService
{
    private readonly ApplicationDbContext _context;

    public LessonService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CreateResponseDto<LessonDto>> CreateAsync(LessonDto dto, CancellationToken cancellationToken = default)
    {
        var entity = dto.ToEntity();

        await _context.Lessons.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return new CreateResponseDto<LessonDto> { Success = true, Item = entity.ToDto(), Id = entity.Id };
    }

    public async Task<UpdateResponseDto<LessonDto>> UpdateAsync(Guid id, LessonDto dto, CancellationToken cancellationToken = default)
    {
        var entity = await _context.Lessons
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (entity == null)
        {
            return new UpdateResponseDto<LessonDto>()
            {
                Success = false,
                ErrorMessage = $"{nameof(Lesson)} not found"
            };
        }

        entity.UpdateEntity(dto);

        _context.Lessons.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return new UpdateResponseDto<LessonDto> { Success = true, Item = entity.ToDto(), Id = entity.Id };
    }

    public async Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await _context.Lessons
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (entity == null)
        {
            return new ResponseDto()
            {
                Success = false,
                ErrorMessage = $"{nameof(Lesson)} not found"
            };
        }

        _context.Lessons.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return new ResponseDto { Success = true };
    }

    public async Task<DetailsResponseDto<LessonDto>> GetById(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await _context.Lessons
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (entity == null)
        {
            return new DetailsResponseDto<LessonDto>()
            {
                Success = false,
                ErrorMessage = $"{nameof(Lesson)} not found"
            };
        }

        return new DetailsResponseDto<LessonDto> { Success = true, Item = entity.ToDto() };
    }

    public async Task<ListResponseDto<LessonDto>> GetAll(CancellationToken cancellationToken = default)
    {
        var entities = await _context.Lessons.ToListAsync(cancellationToken);

        return new ListResponseDto<LessonDto>()
        {
            Success = true,
            Items = entities.Select(x => x.ToDto()).ToList(),
            TotalCount = entities.Count
        };
    }
}
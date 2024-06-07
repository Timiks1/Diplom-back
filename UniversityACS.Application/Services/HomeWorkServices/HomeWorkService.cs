using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using UniversityACS.Application.Mappings;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;
using UniversityACS.Core.Entities;
using UniversityACS.Data.DataContext;

namespace UniversityACS.Application.Services.HomeWorkServices;

public class HomeWorkService : IHomeWorkService
{
    private readonly ApplicationDbContext _context;

    public HomeWorkService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CreateResponseDto<HomeWorkResponseDto>> CreateAsync(HomeWorkDto dto, CancellationToken cancellationToken)
    {
        var entity = dto.ToEntity();

        if (dto.File != null)
        {
            using var memoryStream = new MemoryStream();
            await dto.File.CopyToAsync(memoryStream, cancellationToken);
            entity.File = memoryStream.ToArray();
        }

        await _context.HomeWorks.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new CreateResponseDto<HomeWorkResponseDto>()
        {
            Success = true,
            Item = entity.ToDto(),
            Id = entity.Id
        };
    }

    public async Task<UpdateResponseDto<HomeWorkResponseDto>> UpdateAsync(Guid id, HomeWorkDto dto, CancellationToken cancellationToken)
    {
        var entity = await _context.HomeWorks
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (entity == null)
        {
            return new UpdateResponseDto<HomeWorkResponseDto>()
            {
                Success = false,
                ErrorMessage = $"{nameof(HomeWork)} not found"
            };
        }

        entity.UpdateEntity(dto);

        if (dto.File != null)
        {
            using var memoryStream = new MemoryStream();
            await dto.File.CopyToAsync(memoryStream, cancellationToken);
            entity.File = memoryStream.ToArray();
        }

        _context.HomeWorks.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return new UpdateResponseDto<HomeWorkResponseDto>()
        {
            Success = true,
            Item = entity.ToDto(),
            Id = entity.Id
        };
    }

    public async Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _context.HomeWorks
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (entity == null)
        {
            return new ResponseDto()
            {
                Success = false,
                ErrorMessage = $"{nameof(HomeWork)} not found"
            };
        }

        _context.HomeWorks.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return new ResponseDto() { Success = true };
    }

    public async Task<DetailsResponseDto<HomeWorkResponseDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _context.HomeWorks
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (entity == null)
        {
            return new DetailsResponseDto<HomeWorkResponseDto>()
            {
                Success = false,
                ErrorMessage = $"{nameof(HomeWork)} not found"
            };
        }

        return new DetailsResponseDto<HomeWorkResponseDto>() { Success = true, Item = entity.ToDto() };
    }

    public async Task<ListResponseDto<HomeWorkResponseDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var entities = await _context.HomeWorks
            .ToListAsync(cancellationToken);

        return new ListResponseDto<HomeWorkResponseDto>()
        {
            Items = entities.Select(x => x.ToDto()).ToList(),
            TotalCount = entities.Count,
            Success = true
        };
    }

    public async Task<ResponseDto> CheckAsync(Guid id, bool isChecked, CancellationToken cancellationToken)
    {
        var entity = await _context.HomeWorks
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (entity == null)
        {
            return new ResponseDto()
            {
                Success = false,
                ErrorMessage = $"{nameof(HomeWork)} not found"
            };
        }

        entity.IsChecked = isChecked;

        _context.HomeWorks.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return new ResponseDto() { Success = true };
    }

    public async Task<ResponseDto> GradeAsync(Guid id, int grade, CancellationToken cancellationToken)
    {
        var entity = await _context.HomeWorks
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (entity == null)
        {
            return new ResponseDto()
            {
                Success = false,
                ErrorMessage = $"{nameof(HomeWork)} not found"
            };
        }

        entity.Grade = grade;

        _context.HomeWorks.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return new ResponseDto() { Success = true };
    }
    public async Task<ResponseDto> AddCommentAsync(Guid id, string comment, CancellationToken cancellationToken)
    {
        var entity = await _context.HomeWorks
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (entity == null)
        {
            return new ResponseDto()
            {
                Success = false,
                ErrorMessage = $"{nameof(HomeWork)} not found"
            };
        }

        entity.Comment = comment; // Assuming there is a Comment property in HomeWork entity

        _context.HomeWorks.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return new ResponseDto() { Success = true };
    }

    public async Task<ListResponseDto<HomeWorkResponseDto>> GetByStudentIdDisciplineIdAsync(Guid studentId, Guid disciplineId, CancellationToken cancellationToken)
    {
        var entities = await _context.HomeWorks
            .Where(x => x.StudentId == studentId && x.DisciplineId == disciplineId)
            .ToListAsync(cancellationToken);

        return new ListResponseDto<HomeWorkResponseDto>()
        {
            Items = entities.Select(x => x.ToDto()).ToList(),
            TotalCount = entities.Count,
            Success = true
        };
    }
    public async Task<ListResponseDto<HomeWorkResponseDto>> GetByStudentIdAsync(Guid studentId, CancellationToken cancellationToken)
    {
        var entities = await _context.HomeWorks
            .Where(x => x.StudentId == studentId)
            .ToListAsync(cancellationToken);

        return new ListResponseDto<HomeWorkResponseDto>()
        {
            Items = entities.Select(x => x.ToDto()).ToList(),
            TotalCount = entities.Count,
            Success = true
        };
    }
    public async Task<ResponseDto> UpdateByLessonNameAsync(string lessonName, string description, IFormFile file, CancellationToken cancellationToken)
    {
        var entities = await _context.HomeWorks
            .Where(x => x.Name == lessonName)
            .ToListAsync(cancellationToken);

        foreach (var entity in entities)
        {
            entity.Description = description;

            if (file != null)
            {
                using var memoryStream = new MemoryStream();
                await file.CopyToAsync(memoryStream, cancellationToken);
                entity.File = memoryStream.ToArray();
            }
        }

        _context.HomeWorks.UpdateRange(entities);
        await _context.SaveChangesAsync(cancellationToken);

        return new ResponseDto() { Success = true };
    }
}
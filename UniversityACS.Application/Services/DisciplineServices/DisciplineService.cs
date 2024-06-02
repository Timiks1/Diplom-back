using DocumentFormat.OpenXml.Vml.Office;
using Microsoft.EntityFrameworkCore;
using UniversityACS.Application.Mappings;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.Entities;
using UniversityACS.Data.DataContext;

namespace UniversityACS.Application.Services.DisciplineServices;

public class DisciplineService : IDisciplineService
{
    private readonly ApplicationDbContext _context;

    public DisciplineService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CreateResponseDto<DisciplineDto>> CreateAsync(DisciplineDto dto, CancellationToken cancellationToken)
    {
        var existingDiscipline = await _context.Disciplines
            .FirstOrDefaultAsync(x => x.Name == dto.Name, cancellationToken);

        if (existingDiscipline != null)
        {
            return new CreateResponseDto<DisciplineDto>()
            {
                Success = false,
                ErrorMessage = "Discipline with the same name already exists."
            };
        }

        var discipline = dto.ToEntity();

        _context.Disciplines.Add(discipline);
        await _context.SaveChangesAsync(cancellationToken);

        return new CreateResponseDto<DisciplineDto>() { Success = true, Item = discipline.ToDto(), Id = discipline.Id };
    }

    public async Task<UpdateResponseDto<DisciplineDto>> UpdateAsync(Guid id, DisciplineDto dto, CancellationToken cancellationToken)
    {
        var existingDiscipline = await _context.Disciplines
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (existingDiscipline == null)
        {
            return new UpdateResponseDto<DisciplineDto>()
            {
                Success = false,
                ErrorMessage = "Discipline not found."
            };
        }

        existingDiscipline.UpdateEntity(dto);
        _context.Disciplines.Update(existingDiscipline);
        await _context.SaveChangesAsync(cancellationToken);

        return new UpdateResponseDto<DisciplineDto>()
        {
            Success = true,
            Item = existingDiscipline.ToDto(),
            Id = existingDiscipline.Id
        };
    }

    public async Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var existingDiscipline = await _context.Disciplines
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (existingDiscipline == null)
        {
            return new ResponseDto()
            {
                Success = false,
                ErrorMessage = "Discipline not found."
            };
        }

        _context.Disciplines.Remove(existingDiscipline);
        await _context.SaveChangesAsync(cancellationToken);

        return new ResponseDto() { Success = true };
    }

    public async Task<DetailsResponseDto<DisciplineDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var existingDiscipline = await _context.Disciplines
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (existingDiscipline == null)
        {
            return new DetailsResponseDto<DisciplineDto>()
            {
                Success = false,
                ErrorMessage = "Discipline not found."
            };
        }

        return new DetailsResponseDto<DisciplineDto>()
        {
            Item = existingDiscipline.ToDto(),
            Success = true
        };
    }

    public async Task<ListResponseDto<DisciplineDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var disciplines = await _context.Disciplines
             .ToListAsync(cancellationToken);

        return new ListResponseDto<DisciplineDto>()
        {
            Items = disciplines.Select(x => x.ToDto()).ToList(),
            TotalCount = disciplines.Count,
            Success = true
        };
    }

    public async Task<ListResponseDto<DisciplineDto>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        var disciplinesIds = await _context.TeacherDisciplines
            .Where(x => x.TeacherId == userId)
            .Select(x => x.DisciplineId)
            .ToListAsync(cancellationToken);

        var disciplines = await _context.Disciplines
            .Where(x => disciplinesIds.Contains(x.Id))
            .ToListAsync(cancellationToken);

        return new ListResponseDto<DisciplineDto>()
        {
            Items = disciplines.Select(x => x.ToDto()).ToList(),
            TotalCount = disciplines.Count,
            Success = true
        };
    }
}
using Microsoft.EntityFrameworkCore;
using UniversityACS.Application.Mappings;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;
using UniversityACS.Core.Entities;
using UniversityACS.Data.DataContext;

namespace UniversityACS.Application.Services.StudentsGroupServices;

public class StudentsGroupService : IStudentsGroupService
{
    private readonly ApplicationDbContext _context;

    public StudentsGroupService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CreateResponseDto<StudentsGroupResponseDto>> CreateAsync(StudentsGroupDto dto,
        CancellationToken cancellationToken)
    {
        var entity = dto.ToEntity();

        if (dto.StudentsIds != null)
        {
            entity.Students = new List<ApplicationUser>();
            foreach (var studentId in dto.StudentsIds)
            {
                var student = await _context.ApplicationUsers
                    .FirstOrDefaultAsync(x => x.Id == studentId, cancellationToken);
                if (student != null)
                {
                    entity.Students.Add(student);
                }
            }
        }

        if (dto.DisciplinesIds != null)
        {
            entity.Disciplines = new List<Discipline>();
            foreach (var disciplineId in dto.DisciplinesIds)
            {
                var discipline = await _context.Disciplines
                    .FirstOrDefaultAsync(x => x.Id == disciplineId, cancellationToken);
                if (discipline != null)
                {
                    entity.Disciplines.Add(discipline);
                }
            }
        }

        await _context.StudentsGroups.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        var responseDto = new CreateResponseDto<StudentsGroupResponseDto>()
        {
            Success = true,
            Item = null,
            Id = entity.Id
        };

        return responseDto;
    }

    public async Task<UpdateResponseDto<StudentsGroupResponseDto>> UpdateAsync(Guid id, StudentsGroupDto dto, CancellationToken cancellationToken)
    {
        var entity = await _context.StudentsGroups
            .Include(x => x.Students)
            .Include(x => x.Disciplines)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (entity == null)
        {
            return new UpdateResponseDto<StudentsGroupResponseDto>
            {
                Success = false,
                ErrorMessage = $"{nameof(StudentsGroup)} not found"
            };
        }

        entity.UpdateEntity(dto);

        if (dto.StudentsIds != null)
        {
            // Удаление студентов, которых больше нет в новом списке
            entity.Students.RemoveAll(student => !dto.StudentsIds.Contains(student.Id));

            // Добавление новых студентов
            foreach (var studentId in dto.StudentsIds)
            {
                if (entity.Students.All(s => s.Id != studentId))
                {
                    var student = await _context.ApplicationUsers
                        .FirstOrDefaultAsync(x => x.Id == studentId, cancellationToken);
                    if (student != null)
                    {
                        entity.Students.Add(student);
                    }
                }
            }
        }

        if (dto.DisciplinesIds != null)
        {
            // Удаление дисциплин, которых больше нет в новом списке
            entity.Disciplines.RemoveAll(discipline => !dto.DisciplinesIds.Contains(discipline.Id));

            // Добавление новых дисциплин
            foreach (var disciplineId in dto.DisciplinesIds)
            {
                if (entity.Disciplines.All(d => d.Id != disciplineId))
                {
                    var discipline = await _context.Disciplines
                        .FirstOrDefaultAsync(x => x.Id == disciplineId, cancellationToken);
                    if (discipline != null)
                    {
                        entity.Disciplines.Add(discipline);
                    }
                }
            }
        }

        _context.StudentsGroups.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return new UpdateResponseDto<StudentsGroupResponseDto>
        {
            Success = true,
            Item = entity.ToDto(),
            Id = entity.Id
        };
    }


    public async Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _context.StudentsGroups
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (entity == null)
        {
            return new ResponseDto()
            {
                Success = false,
                ErrorMessage = $"{nameof(StudentsGroup)} not found"
            };
        }

        _context.StudentsGroups.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return new ResponseDto() { Success = true };
    }

    public async Task<DetailsResponseDto<StudentsGroupResponseDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _context.StudentsGroups
            .Include(x => x.Students)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (entity == null)
        {
            return new DetailsResponseDto<StudentsGroupResponseDto>()
            {
                Success = false,
                ErrorMessage = $"{nameof(StudentsGroup)} not found"
            };
        }

        return new DetailsResponseDto<StudentsGroupResponseDto>()
        {
            Item = entity.ToDto(),
            Success = true
        };
    }
    public async Task<ListResponseDto<StudentsGroupResponseDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var entities = await _context.StudentsGroups
           .Include(g => g.Students)
           .Include(g => g.Disciplines)
           .ToListAsync(cancellationToken);

        return new ListResponseDto<StudentsGroupResponseDto>()
        {
            Items = entities.Select(x => x.ToDto()).ToList(),
            TotalCount = entities.Count,
            Success = true
        };
    }
}
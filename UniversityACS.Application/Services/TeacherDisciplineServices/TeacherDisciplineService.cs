using Microsoft.EntityFrameworkCore;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.Entities;
using UniversityACS.Data.DataContext;

namespace UniversityACS.Application.Services.TeacherDisciplineServices;

public class TeacherDisciplineService : ITeacherDisciplineService
{
    private readonly ApplicationDbContext _context;

    public TeacherDisciplineService(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<ResponseDto> UpsertDisciplinesToTeacherAsync(TeacherDisciplinesDto dto, CancellationToken cancellationToken)
    {
        var teacher = await _context.ApplicationUsers
            .Include(x=>x.Disciplines)
            .FirstOrDefaultAsync(x => x.Id == dto.TeacherId, cancellationToken);

        if (teacher == null)
        {
            return new ResponseDto()
            {
                Success = false,
                ErrorMessage = "TeacherNotFound"
            };
        }
        
        var disciplines = await _context.Disciplines
            .Where(x => dto.DisciplineIds.Contains(x.Id))
            .ToListAsync(cancellationToken);

        teacher.Disciplines = teacher.Disciplines?.Concat(disciplines).Distinct().ToList();

        _context.ApplicationUsers.Update(teacher);
        await _context.SaveChangesAsync(cancellationToken);

        return new ResponseDto() { Success = true };
    }

    public async Task<ResponseDto> DeleteDisciplinesFromTeacherAsync(TeacherDisciplinesDto dto, CancellationToken cancellationToken)
    {
        var teacher = await _context.ApplicationUsers
            .FirstOrDefaultAsync(x => x.Id == dto.TeacherId, cancellationToken);

        if (teacher == null)
        {
            return new ResponseDto()
            {
                Success = false,
                ErrorMessage = "TeacherNotFound"
            };
        }

        var existingTeacherDisciplinesList = await _context.TeacherDisciplines
            .Where(x => x.TeacherId == dto.TeacherId)
            .ToListAsync(cancellationToken);
        
        var toDeleteList = dto.DisciplineIds
            .Select(disciplineId => existingTeacherDisciplinesList
                .FirstOrDefault(x => x.DisciplineId == disciplineId))
            .OfType<TeacherDiscipline>()
            .ToList();
        
        _context.TeacherDisciplines.RemoveRange(toDeleteList);
        await _context.SaveChangesAsync(cancellationToken);

        return new ResponseDto()
        {
            Success = true
        };
    }
    public async Task<TeacherDisciplinesDto> GetTeacherDisciplinesDto(Guid id)
    {
        var items = await this._context.TeacherDisciplines.Where(x => x.TeacherId == id).ToListAsync();

        TeacherDisciplinesDto dto = new TeacherDisciplinesDto();
        dto.TeacherId = id;
        dto.DisciplineIds = new List<Guid>();
        foreach (var item in items)
        {
            dto.DisciplineIds.Add(item.DisciplineId);
        }
        return dto;
    }
}
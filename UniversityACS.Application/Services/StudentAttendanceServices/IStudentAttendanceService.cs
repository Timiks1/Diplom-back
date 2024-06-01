using Microsoft.EntityFrameworkCore;
using UniversityACS.Application.Mappings;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.Entities;
using UniversityACS.Data.DataContext;

namespace UniversityACS.Application.Services.StudentAttendanceServices;

public class StudentAttendanceService : IStudentAttendanceService
{
    private readonly ApplicationDbContext _context;

    public StudentAttendanceService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CreateResponseDto<StudentAttendanceDto>> CreateAsync(StudentAttendanceDto dto, CancellationToken cancellationToken)
    {
        var entity = dto.ToEntity();

        await _context.StudentAttendances.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return new CreateResponseDto<StudentAttendanceDto> { Success = true, Item = entity.ToDto(), Id = entity.Id };
    }

    public async Task<UpdateResponseDto<StudentAttendanceDto>> UpdateAsync(Guid id, StudentAttendanceDto dto, CancellationToken cancellationToken)
    {
        var entity = await _context.StudentAttendances
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (entity == null)
        {
            return new UpdateResponseDto<StudentAttendanceDto> { Success = false, ErrorMessage = $"{nameof(StudentAttendance)} not found" };
        }

        entity.UpdateEntity(dto);

        _context.StudentAttendances.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return new UpdateResponseDto<StudentAttendanceDto> { Success = true, Item = entity.ToDto(), Id = entity.Id };
    }

    public async Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _context.StudentAttendances
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (entity == null)
        {
            return new ResponseDto { Success = false, ErrorMessage = $"{nameof(StudentAttendance)} not found" };
        }

        _context.StudentAttendances.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return new ResponseDto { Success = true };
    }

    public async Task<DetailsResponseDto<StudentAttendanceDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _context.StudentAttendances
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (entity == null)
        {
            return new DetailsResponseDto<StudentAttendanceDto> { Success = false, ErrorMessage = $"{nameof(StudentAttendance)} not found" };
        }

        return new DetailsResponseDto<StudentAttendanceDto> { Success = true, Item = entity.ToDto() };
    }

    public async Task<ListResponseDto<StudentAttendanceDto>> GetByStudentIdAsync(Guid studentId, CancellationToken cancellationToken)
    {
        var entities = await _context.StudentAttendances
            .Where(x => x.StudentId == studentId)
            .ToListAsync(cancellationToken);

        return new ListResponseDto<StudentAttendanceDto>()
        {
            Items = entities.Select(x => x.ToDto()).ToList(),
            TotalCount = entities.Count,
            Success = true
        };
    }

    public async Task<ListResponseDto<StudentAttendanceDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var entities = await _context.StudentAttendances
            .ToListAsync(cancellationToken);

        return new ListResponseDto<StudentAttendanceDto>()
        {
            Items = entities.Select(x => x.ToDto()).ToList(),
            TotalCount = entities.Count,
            Success = true
        };
    }
}
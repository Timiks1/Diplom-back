using Microsoft.EntityFrameworkCore;
using UniversityACS.Application.Mappings;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;
using UniversityACS.Data.DataContext;
using OfficeOpenXml;
namespace UniversityACS.Application.Services.ScheduleServices;

public class ScheduleService : IScheduleService
{
    private readonly ApplicationDbContext _context;

    public ScheduleService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CreateResponseDto<ScheduleDto>> CreateAsync(ScheduleDto dto, CancellationToken cancellationToken)
    {
        var entity = dto.ToEntity();

        if (dto.File != null)
        {
            using var memoryStream = new MemoryStream();
            await dto.File.CopyToAsync(memoryStream, cancellationToken);
            entity.File = memoryStream.ToArray();
        }


        await _context.Schedules.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new CreateResponseDto<ScheduleDto>()
        {
            Success = true,
            Id = entity.Id
        };
    }


    public async Task<UpdateResponseDto<ScheduleDto>> UpdateAsync(Guid id, ScheduleDto dto, CancellationToken cancellationToken)
    {
        var entity = await _context.Schedules
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (entity == null)
        {
            return new UpdateResponseDto<ScheduleDto>()
            {
                Success = false,
                ErrorMessage = "Schedule not found"
            };
        }

        entity.UpdateEntity(dto);
        if (dto.File != null)
        {
            using var memoryStream = new MemoryStream();
            await dto.File.CopyToAsync(memoryStream, cancellationToken);
            entity.File = memoryStream.ToArray();
        }

        _context.Schedules.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return new UpdateResponseDto<ScheduleDto>() { Success = true, Id = entity.Id };
    }

    public async Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _context.Schedules
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (entity == null)
        {
            return new ResponseDto()
            {
                Success = false,
                ErrorMessage = "Schedule not found"
            };
        }

        _context.Schedules.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return new ResponseDto() { Success = true };
    }

    public async Task<DetailsResponseDto<ScheduleResponseDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _context.Schedules
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (entity == null)
        {
            return new DetailsResponseDto<ScheduleResponseDto>()
            {
                Success = false,
                ErrorMessage = "Schedule not found"
            };
        }

        return new DetailsResponseDto<ScheduleResponseDto>()
        {
            Success = true,
            Item = entity.ToDto()
        };
    }

    public async Task<ListResponseDto<ScheduleResponseDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var entities = await _context.Schedules
            .ToListAsync(cancellationToken);

        return new ListResponseDto<ScheduleResponseDto>()
        {
            Success = true,
            Items = entities.Select(x => x.ToDto()).ToList(),
            TotalCount = entities.Count
        };
    }

    public async Task<ListResponseDto<ScheduleResponseDto>> GetByDepartmentIdAsync(Guid departmentId, CancellationToken cancellationToken)
    {
        var entities = await _context.Schedules
            .Where(x => x.DepartmentId == departmentId)
            .ToListAsync(cancellationToken);

        return new ListResponseDto<ScheduleResponseDto>()
        {
            Success = true,
            Items = entities.Select(x => x.ToDto()).ToList(),
            TotalCount = entities.Count
        };
    }
    public async Task<byte[]> GetFileByNameAsync(string fileName, CancellationToken cancellationToken)
    {
        var schedule = await _context.Schedules
            .FirstOrDefaultAsync(x => x.Name == fileName, cancellationToken);
        return schedule?.File;
    }
    public async Task<List<ScheduleDto>> GetSchedulesByTeacherAsync(string fileName, Guid teacherId, CancellationToken cancellationToken)
    {
        var schedule = await _context.Schedules
            .FirstOrDefaultAsync(x => x.Name == fileName, cancellationToken);

        if (schedule?.File == null)
        {
            return null;
        }

        // Установка контекста лицензии
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        using var memoryStream = new MemoryStream(schedule.File);
        using var package = new ExcelPackage(memoryStream);
        var worksheet = package.Workbook.Worksheets[0]; // Предполагается, что данные на первом листе

        var schedules = new List<ScheduleDto>();

        for (int row = 2; row <= worksheet.Dimension.Rows; row++)
        {
            var teacherIdString = worksheet.Cells[row, 6].GetValue<string>();
            if (Guid.TryParse(teacherIdString, out Guid currentTeacherId) && currentTeacherId == teacherId)
            {
                var dto = new ScheduleDto
                {
                    Date = worksheet.Cells[row, 1].GetValue<DateTime>(),
                    Lesson = worksheet.Cells[row, 2].GetValue<string>(),
                    Teacher = worksheet.Cells[row, 3].GetValue<string>(),
                    Time = worksheet.Cells[row, 4].GetValue<TimeSpan>(),
                    Description = worksheet.Cells[row, 5].GetValue<string>(),
                    TeacherId = currentTeacherId,
                    GroupName = worksheet.Cells[row, 7].GetValue<string>()  // Новое поле

                };
                schedules.Add(dto);
            }
        }

        return schedules;
    }

    public async Task<List<ScheduleDto>> GetSchedulesByTeacherAndDayAsync(string fileName, Guid teacherId, DateTime day, CancellationToken cancellationToken)
    {
        var schedule = await _context.Schedules
            .FirstOrDefaultAsync(x => x.Name == fileName, cancellationToken);

        if (schedule?.File == null)
        {
            return null;
        }

        // Установка контекста лицензии
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        using var memoryStream = new MemoryStream(schedule.File);
        using var package = new ExcelPackage(memoryStream);
        var worksheet = package.Workbook.Worksheets[0]; // Предполагается, что данные на первом листе

        var schedules = new List<ScheduleDto>();

        for (int row = 2; row <= worksheet.Dimension.Rows; row++)
        {
            var date = worksheet.Cells[row, 1].GetValue<DateTime>();
            var teacherIdString = worksheet.Cells[row, 6].GetValue<string>();
            if (date.Date == day.Date && Guid.TryParse(teacherIdString, out Guid currentTeacherId) && currentTeacherId == teacherId)
            {
                var dto = new ScheduleDto
                {
                    Date = date,
                    Lesson = worksheet.Cells[row, 2].GetValue<string>(),
                    Teacher = worksheet.Cells[row, 3].GetValue<string>(),
                    Time = worksheet.Cells[row, 4].GetValue<TimeSpan>(),
                    Description = worksheet.Cells[row, 5].GetValue<string>(),
                    TeacherId = currentTeacherId,
                    GroupName = worksheet.Cells[row, 7].GetValue<string>()  // Новое поле
                };
                schedules.Add(dto);
            }
        }

        return schedules;
    }
}


using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;

namespace UniversityACS.Application.Services.ScheduleServices;

public interface IScheduleService
{
    Task<CreateResponseDto<ScheduleDto>> CreateAsync(ScheduleDto dto,
        CancellationToken cancellationToken = default!);
    Task<UpdateResponseDto<ScheduleDto>> UpdateAsync(Guid id, ScheduleDto dto,
        CancellationToken cancellationToken = default!);
    Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken = default!);
    Task<DetailsResponseDto<ScheduleResponseDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default!);
    Task<ListResponseDto<ScheduleResponseDto>> GetAllAsync(CancellationToken cancellationToken = default!);
    Task<ListResponseDto<ScheduleResponseDto>> GetByDepartmentIdAsync(Guid departmentId, CancellationToken cancellationToken = default!);
    Task<byte[]> GetFileByNameAsync(string fileName, CancellationToken cancellationToken);
    Task<List<ScheduleDto>> GetSchedulesByTeacherAsync(string fileName, Guid teacherId, CancellationToken cancellationToken);
    Task<List<ScheduleDto>> GetSchedulesByTeacherAndDayAsync(string fileName, Guid teacherId, DateTime day, CancellationToken cancellationToken);
    Task<ResponseDto> UpdateScheduleFileAsync(string fileName, byte[] updatedFile, CancellationToken cancellationToken);
}
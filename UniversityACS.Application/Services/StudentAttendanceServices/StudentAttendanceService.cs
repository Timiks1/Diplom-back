using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;

namespace UniversityACS.Application.Services.StudentAttendanceServices;

public interface IStudentAttendanceService
{
    Task<CreateResponseDto<StudentAttendanceDto>> CreateAsync(StudentAttendanceDto dto,
        CancellationToken cancellationToken = default!);
    Task<UpdateResponseDto<StudentAttendanceDto>> UpdateAsync(Guid id, StudentAttendanceDto dto,
        CancellationToken cancellationToken = default!);
    Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken = default!);
    Task<DetailsResponseDto<StudentAttendanceDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default!);
    Task<ListResponseDto<StudentAttendanceDto>> GetByStudentIdAsync(Guid studentId,
        CancellationToken cancellationToken = default!);
    Task<ListResponseDto<StudentAttendanceDto>> GetAllAsync(CancellationToken cancellationToken = default!);
}
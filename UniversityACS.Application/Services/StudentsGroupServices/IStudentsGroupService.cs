using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;

namespace UniversityACS.Application.Services.StudentsGroupServices;

public interface IStudentsGroupService
{
    Task<CreateResponseDto<StudentsGroupResponseDto>> CreateAsync(StudentsGroupDto dto,
        CancellationToken cancellationToken = default!);
    Task<UpdateResponseDto<StudentsGroupResponseDto>> UpdateAsync(Guid id, StudentsGroupDto dto,
        CancellationToken cancellationToken = default!);
    Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken = default!);
    Task<DetailsResponseDto<StudentsGroupResponseDto>> GetByIdAsync(Guid id,
        CancellationToken cancellationToken = default!);
    Task<ListResponseDto<StudentsGroupResponseDto>> GetAllAsync(CancellationToken cancellationToken = default!);
}
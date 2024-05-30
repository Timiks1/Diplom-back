using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;

namespace UniversityACS.Application.Services.SyllabusServices;

public interface ISyllabusService
{
    Task<CreateResponseDto<SyllabusDto>> CreateAsync(SyllabusDto dto,
        CancellationToken cancellationToken = default!);
    Task<UpdateResponseDto<SyllabusDto>> UpdateAsync(Guid id, SyllabusDto dto,
        CancellationToken cancellationToken = default!);
    Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken = default!);
    Task<DetailsResponseDto<SyllabusResponseDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default!);
    Task<ListResponseDto<SyllabusResponseDto>> GetAllAsync(CancellationToken cancellationToken = default!);
    Task<ListResponseDto<SyllabusResponseDto>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default!);
    Task<Guid> CreateSyllabusFromJsonAsync(SyllabusFileDto syllabusDto, Guid teacherId, string fileName, CancellationToken cancellationToken);

}
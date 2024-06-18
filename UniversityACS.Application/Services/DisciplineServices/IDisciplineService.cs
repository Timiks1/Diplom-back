using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;

namespace UniversityACS.Application.Services.DisciplineServices;

public interface IDisciplineService
{
    Task<CreateResponseDto<DisciplineDto>> CreateAsync(DisciplineDto dto,
        CancellationToken cancellationToken = default!);
    Task<UpdateResponseDto<DisciplineDto>> UpdateAsync(Guid id, DisciplineDto dto,
        CancellationToken cancellationToken = default!);
    Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken = default!);
    Task<DetailsResponseDto<DisciplineDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default!);
    Task<ListResponseDto<DisciplineDto>> GetAllAsync(CancellationToken cancellationToken = default!);
    Task<ListResponseDto<DisciplineDto>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default!);
    Task<ResponseDto> ClearAsync(CancellationToken cancellationToken);

}
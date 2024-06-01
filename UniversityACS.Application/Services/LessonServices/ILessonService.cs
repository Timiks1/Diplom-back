using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;

namespace UniversityACS.Application.Services.LessonServices;

public interface ILessonService
{
    Task<CreateResponseDto<LessonDto>> CreateAsync(LessonDto dto, CancellationToken cancellationToken = default!);
    Task<UpdateResponseDto<LessonDto>> UpdateAsync(Guid id, LessonDto dto, CancellationToken cancellationToken = default!);
    Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken = default!);
    Task<DetailsResponseDto<LessonDto>> GetById(Guid id, CancellationToken cancellationToken = default!);
    Task<ListResponseDto<LessonDto>> GetAll(CancellationToken cancellationToken = default!);
}
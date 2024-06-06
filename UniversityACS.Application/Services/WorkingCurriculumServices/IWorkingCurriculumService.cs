using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;

namespace UniversityACS.Application.Services.WorkingCurriculumServices;

public interface IWorkingCurriculumService
{
    Task<CreateResponseDto<WorkingCurriculumDto>> CreateAsync(WorkingCurriculumDto dto,
        CancellationToken cancellationToken = default!);
    Task<UpdateResponseDto<WorkingCurriculumDto>> UpdateAsync(Guid id, WorkingCurriculumDto dto,
        CancellationToken cancellationToken = default!);
    Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken = default!);
    Task<DetailsResponseDto<WorkingCurriculumResponseDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default!);
    Task<ListResponseDto<WorkingCurriculumResponseDto>> GetAllAsync(CancellationToken cancellationToken = default!);
    Task<ListResponseDto<WorkingCurriculumResponseDto>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default!);
    Task<ListResponseDto<WorkingCurriculumResponseDto>> GetByLessonIdAsync(Guid lessonId, CancellationToken cancellationToken);
}
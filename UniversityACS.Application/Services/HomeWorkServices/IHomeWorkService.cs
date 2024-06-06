using Microsoft.AspNetCore.Http;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;

namespace UniversityACS.Application.Services.HomeWorkServices;

public interface IHomeWorkService
{
    Task<CreateResponseDto<HomeWorkResponseDto>> CreateAsync(HomeWorkDto dto,
        CancellationToken cancellationToken = default!);
    Task<UpdateResponseDto<HomeWorkResponseDto>> UpdateAsync(Guid id, HomeWorkDto dto,
        CancellationToken cancellationToken = default!);
    Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken = default!);
    Task<DetailsResponseDto<HomeWorkResponseDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default!);
    Task<ListResponseDto<HomeWorkResponseDto>> GetAllAsync(CancellationToken cancellationToken = default!);
    Task<ResponseDto> CheckAsync(Guid id, bool isChecked, CancellationToken cancellationToken = default!);
    Task<ResponseDto> GradeAsync(Guid id, int grade, CancellationToken cancellationToken = default!);
    Task<ListResponseDto<HomeWorkResponseDto>> GetByStudentIdDisciplineIdAsync(Guid studentId, Guid disciplineId,
        CancellationToken cancellationToken = default!);
    Task<ListResponseDto<HomeWorkResponseDto>> GetByStudentIdAsync(Guid studentId, CancellationToken cancellationToken);
    Task<ResponseDto> UpdateByLessonNameAsync(string lessonName, string description, IFormFile file, CancellationToken cancellationToken);
    Task<ResponseDto> AddCommentAsync(Guid id, string comment, CancellationToken cancellationToken);
}
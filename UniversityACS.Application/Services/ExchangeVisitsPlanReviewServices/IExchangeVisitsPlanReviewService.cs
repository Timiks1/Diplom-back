using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;
using UniversityACS.Core.DTOs;

namespace UniversityACS.Application.Services.ExchangeVisitsPlanReviewServices
{
    public interface IExchangeVisitsPlanReviewService
    {
        Task<CreateResponseDto<ExchangeVisitsPlanReviewDto>> CreateAsync(ExchangeVisitsPlanReviewDto dto, CancellationToken cancellationToken);
        Task<UpdateResponseDto<ExchangeVisitsPlanReviewDto>> UpdateAsync(Guid id, ExchangeVisitsPlanReviewDto dto, CancellationToken cancellationToken);
        Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken);
        Task<DetailsResponseDto<ExchangeVisitsPlanReviewResponseDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<ListResponseDto<ExchangeVisitsPlanReviewResponseDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<ListResponseDto<ExchangeVisitsPlanReviewResponseDto>> GetByTeacherIdAsync(Guid teacherId, CancellationToken cancellationToken); // Новый метод

    }
}

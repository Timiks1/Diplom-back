using Microsoft.EntityFrameworkCore;
using UniversityACS.Application.Mappings;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;
using UniversityACS.Core.Entities;
using UniversityACS.Data.DataContext;


namespace UniversityACS.Application.Services.ExchangeVisitsPlanReviewServices
{
    public class ExchangeVisitsPlanReviewService : IExchangeVisitsPlanReviewService
    {
        private readonly ApplicationDbContext _context;

        public ExchangeVisitsPlanReviewService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CreateResponseDto<ExchangeVisitsPlanReviewDto>> CreateAsync(ExchangeVisitsPlanReviewDto dto, CancellationToken cancellationToken)
        {
            var review = new ExchangeVisitsPlanReviews
            {
                Id = Guid.NewGuid(),
                TeacherId = dto.TeacherId,
                ExchangeVisitsPlan = dto.ExchangeVisitsPlan,
                Name = dto.Name
            };

            if (dto.File != null)
            {
                using var memoryStream = new MemoryStream();
                await dto.File.CopyToAsync(memoryStream, cancellationToken);
                review.File = memoryStream.ToArray();
            }

            await _context.ExchangeVisitsPlanReviews.AddAsync(review, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return new CreateResponseDto<ExchangeVisitsPlanReviewDto> { Success = true, Id = review.Id };
        }

        public async Task<UpdateResponseDto<ExchangeVisitsPlanReviewDto>> UpdateAsync(Guid id, ExchangeVisitsPlanReviewDto dto, CancellationToken cancellationToken)
        {
            var review = await _context.ExchangeVisitsPlanReviews.FindAsync(new object[] { id }, cancellationToken);

            if (review == null)
            {
                return new UpdateResponseDto<ExchangeVisitsPlanReviewDto> { Success = false, ErrorMessage = "Review not found" };
            }

            review.TeacherId = dto.TeacherId;
            review.ExchangeVisitsPlan = dto.ExchangeVisitsPlan;
            review.Name = dto.Name;

            if (dto.File != null)
            {
                using var memoryStream = new MemoryStream();
                await dto.File.CopyToAsync(memoryStream, cancellationToken);
                review.File = memoryStream.ToArray();
            }

            _context.ExchangeVisitsPlanReviews.Update(review);
            await _context.SaveChangesAsync(cancellationToken);

            return new UpdateResponseDto<ExchangeVisitsPlanReviewDto> { Success = true, Id = review.Id };
        }

        public async Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var review = await _context.ExchangeVisitsPlanReviews.FindAsync(new object[] { id }, cancellationToken);

            if (review == null)
            {
                return new ResponseDto { Success = false, ErrorMessage = "Review not found" };
            }

            _context.ExchangeVisitsPlanReviews.Remove(review);
            await _context.SaveChangesAsync(cancellationToken);

            return new ResponseDto { Success = true };
        }

        public async Task<DetailsResponseDto<ExchangeVisitsPlanReviewResponseDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var review = await _context.ExchangeVisitsPlanReviews.FindAsync(new object[] { id }, cancellationToken);

            if (review == null)
            {
                return new DetailsResponseDto<ExchangeVisitsPlanReviewResponseDto> { Success = false, ErrorMessage = "Review not found" };
            }

            return new DetailsResponseDto<ExchangeVisitsPlanReviewResponseDto>
            {
                Success = true,
                Item = new ExchangeVisitsPlanReviewResponseDto
                {
                    Id = review.Id,
                    TeacherId = review.TeacherId,
                    ExchangeVisitsPlan = review.ExchangeVisitsPlan,
                    Name = review.Name,
                    File = review.File
                }
            };
        }

        public async Task<ListResponseDto<ExchangeVisitsPlanReviewResponseDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            var reviews = await _context.ExchangeVisitsPlanReviews.ToListAsync(cancellationToken);

            return new ListResponseDto<ExchangeVisitsPlanReviewResponseDto>
            {
                Success = true,
                Items = reviews.Select(review => new ExchangeVisitsPlanReviewResponseDto
                {
                    Id = review.Id,
                    TeacherId = review.TeacherId,
                    ExchangeVisitsPlan = review.ExchangeVisitsPlan,
                    Name = review.Name,
                    File = review.File
                }).ToList(),
                TotalCount = reviews.Count
            };
        }
        public async Task<ListResponseDto<ExchangeVisitsPlanReviewResponseDto>> GetByTeacherIdAsync(Guid teacherId, CancellationToken cancellationToken)
        {
            var reviews = await _context.ExchangeVisitsPlanReviews
                .Where(x => x.TeacherId == teacherId)
                .ToListAsync(cancellationToken);

            return new ListResponseDto<ExchangeVisitsPlanReviewResponseDto>
            {
                Success = true,
                Items = reviews.Select(review => new ExchangeVisitsPlanReviewResponseDto
                {
                    Id = review.Id,
                    TeacherId = review.TeacherId,
                    ExchangeVisitsPlan = review.ExchangeVisitsPlan,
                    Name = review.Name,
                    File = review.File
                }).ToList(),
                TotalCount = reviews.Count
            };
        }
    }
}
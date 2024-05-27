using Microsoft.AspNetCore.Mvc;
using UniversityACS.API.Endpoints;
using UniversityACS.Application.Services.ReviewServices;
using UniversityACS.Core.Entities;

namespace UniversityACS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Route(ApiEndpoints.Reviews.Base)]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpPost]
        [Route(ApiEndpoints.Reviews.Create)]
        public async Task<IActionResult> AddReview([FromBody] Review review)
        {
            if (review == null)
            {
                return BadRequest("Review data is null.");
            }

            try
            {
                var addedReview = await _reviewService.AddReviewAsync(review);
                return Ok(addedReview);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        [Route(ApiEndpoints.Reviews.GetByStudentId)]
        public async Task<IActionResult> GetReviewsByStudentId(Guid studentId)
        {
            var reviews = await _reviewService.GetReviewsByStudentIdAsync(studentId);
            return Ok(reviews);
        }

        [HttpGet]
        [Route(ApiEndpoints.Reviews.GetByTeacherId)]
        public async Task<IActionResult> GetReviewsByTeacherId(Guid teacherId)
        {
            var reviews = await _reviewService.GetReviewsByTeacherIdAsync(teacherId);
            return Ok(reviews);
        }
    }
}

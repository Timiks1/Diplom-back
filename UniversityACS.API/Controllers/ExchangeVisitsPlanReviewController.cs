using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityACS.Application.Services.ExchangeVisitsPlanReviewServices;
using UniversityACS.Core.DTOs.Requests;

namespace UniversityACS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeVisitsPlanReviewController : ControllerBase
    {
        private readonly IExchangeVisitsPlanReviewService _service;

        public ExchangeVisitsPlanReviewController(IExchangeVisitsPlanReviewService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ExchangeVisitsPlanReviewDto dto, CancellationToken cancellationToken)
        {
            var result = await _service.CreateAsync(dto, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromForm] ExchangeVisitsPlanReviewDto dto, CancellationToken cancellationToken)
        {
            var result = await _service.UpdateAsync(id, dto, cancellationToken);
            if (!result.Success)
            {
                return NotFound(result.ErrorMessage);
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var result = await _service.DeleteAsync(id, cancellationToken);
            if (!result.Success)
            {
                return NotFound(result.ErrorMessage);
            }
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var result = await _service.GetByIdAsync(id, cancellationToken);
            if (!result.Success)
            {
                return NotFound(result.ErrorMessage);
            }
            return Ok(result.Item);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _service.GetAllAsync(cancellationToken);
            return Ok(result);
        }
        [HttpGet("by-teacher/{teacherId}")]
        public async Task<IActionResult> GetByTeacherId(Guid teacherId, CancellationToken cancellationToken)
        {
            var result = await _service.GetByTeacherIdAsync(teacherId, cancellationToken);
            return Ok(result);
        }
    }
}
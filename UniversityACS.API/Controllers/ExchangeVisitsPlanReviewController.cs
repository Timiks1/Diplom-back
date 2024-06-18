using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityACS.Application.Services.ApplicationUserServices;
using UniversityACS.Application.Services.ExchangeVisitsPlanReviewServices;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;

namespace UniversityACS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeVisitsPlanReviewController : ControllerBase
    {
        private readonly IExchangeVisitsPlanReviewService _service;
        private readonly IApplicationUserService _applicationUserService;
        private readonly string templatePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates", "ExchangeVisitPlansReview.docx");

        public ExchangeVisitsPlanReviewController(IExchangeVisitsPlanReviewService service, IApplicationUserService applicationUserService)
        {
            _service = service;
            _applicationUserService = applicationUserService;
        }



        [HttpPost]
        public async Task<ActionResult<CreateResponseDto<ExchangeVisitsPlanDto>>> CreateAsync(Guid teacherId, CancellationToken cancellationToken)
        {

            ExchangeVisitsPlanReviewDto dto = new ExchangeVisitsPlanReviewDto();
            var user = await _applicationUserService.GetByIdAsync(teacherId, cancellationToken);
            dto.TeacherId = teacherId;
            dto.Name = $"Відгук {user.Item.LastName}.docx";
            byte[] fileBytes = System.IO.File.ReadAllBytes(templatePath);
            MemoryStream memoryStream = new MemoryStream(fileBytes);
            dto.File = new FormFile(memoryStream, 0, memoryStream.Length, Path.GetFileName(templatePath), Path.GetFileName(templatePath));
            await _service.CreateAsync(dto, cancellationToken);

            memoryStream.Position = 0;
            return File(memoryStream.ToArray(), "application/vnd.openxmlformats-officedocument.wordprocessingml.document", $"Відгук {user.Item.LastName}.docx");
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
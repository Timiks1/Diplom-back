using Microsoft.AspNetCore.Mvc;
using UniversityACS.API.Endpoints;
using UniversityACS.Application.Services.ExchangeVisitPlanServices;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;

namespace UniversityACS.API.Controllers;

[ApiController]
[Route(ApiEndpoints.ExchangeVisitsPlans.Base)]
public class ExchangeVisitsPlansController : ControllerBase
{
    private readonly IExchangeVisitPlanService _exchangeVisitPlanService;
    private readonly string templatePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates", "ExchangeVisitPlans.docx");

    public ExchangeVisitsPlansController(IExchangeVisitPlanService exchangeVisitPlanService)
    {
        _exchangeVisitPlanService = exchangeVisitPlanService;
    }

    [HttpPost(ApiEndpoints.ExchangeVisitsPlans.Create)]
    public async Task<ActionResult<CreateResponseDto<ExchangeVisitsPlanDto>>> CreateAsync(Guid teacherId, CancellationToken cancellationToken)
    {

        ExchangeVisitsPlanDto dto = new ExchangeVisitsPlanDto();
        dto.TeacherId = teacherId;
        dto.Name = $"Графік взаємовідвідування 1 сем. 2023-2024.docx";
        byte[] fileBytes = System.IO.File.ReadAllBytes(templatePath);
        MemoryStream memoryStream = new MemoryStream(fileBytes);
        dto.File = new FormFile(memoryStream, 0, memoryStream.Length, Path.GetFileName(templatePath), Path.GetFileName(templatePath));
        await _exchangeVisitPlanService.CreateAsync(dto, cancellationToken);

        memoryStream.Position = 0;
        return File(memoryStream.ToArray(), "application/vnd.openxmlformats-officedocument.wordprocessingml.document", $"Графік взаємовідвідування 1 сем. 2023-2024.docx");
    }

    [HttpPut(ApiEndpoints.ExchangeVisitsPlans.Update)]
    public async Task<ActionResult<UpdateResponseDto<ExchangeVisitsPlanResponseDto>>> UpdateAsync(Guid id,
        ExchangeVisitsPlanDto dto, CancellationToken cancellationToken)
    {
        var response = await _exchangeVisitPlanService.UpdateAsync(id, dto, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpDelete(ApiEndpoints.ExchangeVisitsPlans.Delete)]
    public async Task<ActionResult<ResponseDto>> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var response = await _exchangeVisitPlanService.DeleteAsync(id, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpGet(ApiEndpoints.ExchangeVisitsPlans.GetById)]
    public async Task<ActionResult<DetailsResponseDto<ExchangeVisitsPlanResponseDto>>> GetByIdAsync(Guid id,
        CancellationToken cancellationToken)
    {
        var response = await _exchangeVisitPlanService.GetByIdAsync(id, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpGet(ApiEndpoints.ExchangeVisitsPlans.GetByUserId)]
    public async Task<ActionResult<ListResponseDto<ExchangeVisitsPlanResponseDto>>> GetByUserIdAsync(Guid userId,
        CancellationToken cancellationToken)
    {
        var response = await _exchangeVisitPlanService.GetByUserIdAsync(userId, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpGet(ApiEndpoints.ExchangeVisitsPlans.GetAll)]
    public async Task<ActionResult<ListResponseDto<ExchangeVisitsPlanResponseDto>>> GetAllAsync(
        CancellationToken cancellationToken)
    {
        var response = await _exchangeVisitPlanService.GetAllAsync(cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
}
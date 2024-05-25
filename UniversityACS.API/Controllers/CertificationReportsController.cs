using Microsoft.AspNetCore.Mvc;
using UniversityACS.API.Endpoints;
using UniversityACS.Application.Services.CertificationReportServices;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;

namespace UniversityACS.API.Controllers;

[ApiController]
[Route(ApiEndpoints.CertificationReports.Base)]
public class CertificationReportsController : ControllerBase
{
    private readonly ICertificationReportService _certificationReportService;

    public CertificationReportsController(ICertificationReportService certificationReportService)
    {
        _certificationReportService = certificationReportService;
    }

    [HttpPost(ApiEndpoints.CertificationReports.Create)]
    public async Task<ActionResult<CreateResponseDto<CertificationReportDto>>> CreateAsync(CertificationReportDto dto,
        CancellationToken cancellationToken = default)
    {
        var response = await _certificationReportService.CreateAsync(dto, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpPut(ApiEndpoints.CertificationReports.Update)]
    public async Task<ActionResult<UpdateResponseDto<CertificationReportDto>>> UpdateAsync(Guid id,
        CertificationReportDto dto, CancellationToken cancellationToken = default)
    {
        var response = await _certificationReportService.UpdateAsync(id, dto, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpDelete(ApiEndpoints.CertificationReports.Delete)]
    public async Task<ActionResult<ResponseDto>> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var response = await _certificationReportService.DeleteAsync(id, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpGet(ApiEndpoints.CertificationReports.GetById)]
    public async Task<ActionResult<DetailsResponseDto<CertificationReportResponseDto>>> GetByIdAsync(Guid id,
        CancellationToken cancellationToken = default)
    {
        var response = await _certificationReportService.GetByIdAsync(id, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpGet(ApiEndpoints.CertificationReports.GetAll)]
    public async Task<ActionResult<ListResponseDto<CertificationReportResponseDto>>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        var response = await _certificationReportService.GetAllAsync(cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
}
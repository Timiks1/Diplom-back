using Microsoft.AspNetCore.Mvc;
using UniversityACS.API.Endpoints;
using UniversityACS.Application.Services.SyllabusServices;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.Entities;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace UniversityACS.API.Controllers;

[ApiController]
[Route(ApiEndpoints.Syllabi.Base)]
public class SyllabiController : ControllerBase
{
    private readonly ISyllabusService _syllabusService;

    public SyllabiController(ISyllabusService syllabusService)
    {
        _syllabusService = syllabusService;
    }

    [HttpPost(ApiEndpoints.Syllabi.Create)]
    public async Task<ActionResult<CreateResponseDto<SyllabusDto>>> CreateAsync(SyllabusDto dto,
        CancellationToken cancellationToken)
    {
        var response = await _syllabusService.CreateAsync(dto, cancellationToken);
        return response.Success ? Ok(response) : BadRequest(response);
    }

    [HttpDelete(ApiEndpoints.Syllabi.Delete)]
    public async Task<ActionResult<ResponseDto>> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var response = await _syllabusService.DeleteAsync(id, cancellationToken);
        return response.Success ? Ok(response) : BadRequest(response);
    }

    [HttpPut(ApiEndpoints.Syllabi.Update)]
    public async Task<ActionResult<UpdateResponseDto<SyllabusDto>>> UpdateAsync(Guid id, SyllabusDto dto,
        CancellationToken cancellationToken)
    {
        var response = await _syllabusService.UpdateAsync(id, dto, cancellationToken);
        return response.Success ? Ok(response) : BadRequest(response);
    }

    [HttpGet(ApiEndpoints.Syllabi.GetById)]
    public async Task<ActionResult<DetailsResponseDto<SyllabusDto>>> GetByIdAsync(Guid id,
        CancellationToken cancellationToken)
    {
        var response = await _syllabusService.GetByIdAsync(id, cancellationToken);
        return response.Success ? Ok(response) : BadRequest(response);
    }

    [HttpGet(ApiEndpoints.Syllabi.GetAll)]
    public async Task<ActionResult<ListResponseDto<SyllabusDto>>> GetAllAsync(CancellationToken cancellationToken)
    {
        var response = await _syllabusService.GetAllAsync(cancellationToken);
        return response.Success ? Ok(response) : BadRequest(response);
    }

    [HttpGet(ApiEndpoints.Syllabi.GetByUserId)]
    public async Task<ActionResult<ListResponseDto<SyllabusDto>>> GetByUserIdAsync(Guid userId,
        CancellationToken cancellationToken)
    {
        var response = await _syllabusService.GetByUserIdAsync(userId, cancellationToken);
        return response.Success ? Ok(response) : BadRequest(response);
    }

    [HttpPost(ApiEndpoints.Syllabi.CreateFromJson)]
    public async Task<IActionResult> CreateSyllabusFromJson([FromBody] SyllabusFileDto syllabusDto, [FromQuery] Guid teacherId, [FromQuery] string fileName, CancellationToken cancellationToken)
    {
        if (syllabusDto == null)
        {
            return BadRequest("Invalid syllabus data.");
        }

        var syllabusId = await _syllabusService.CreateSyllabusFromJsonAsync(syllabusDto, teacherId, fileName, cancellationToken);

        return Ok(new { Id = syllabusId });
    }
}

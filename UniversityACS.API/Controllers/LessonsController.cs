using Microsoft.AspNetCore.Mvc;
using UniversityACS.API.Endpoints;
using UniversityACS.Application.Services.LessonServices;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;

namespace UniversityACS.API.Controllers;

[ApiController]
[Route(ApiEndpoints.Lessons.Base)]
public class LessonsController : ControllerBase
{
    private readonly ILessonService _lessonService;

    public LessonsController(ILessonService lessonService)
    {
        _lessonService = lessonService;
    }

    [HttpPost(ApiEndpoints.Lessons.Create)]
    public async Task<ActionResult<CreateResponseDto<LessonDto>>> CreateAsync(LessonDto dto,
        CancellationToken cancellationToken = default)
    {
        var response = await _lessonService.CreateAsync(dto, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpPut(ApiEndpoints.Lessons.Update)]
    public async Task<ActionResult<UpdateResponseDto<LessonDto>>> UpdateAsync(Guid id, LessonDto dto,
        CancellationToken cancellationToken = default)
    {
        var response = await _lessonService.UpdateAsync(id, dto, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpDelete(ApiEndpoints.Lessons.Delete)]
    public async Task<ActionResult<ResponseDto>> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var response = await _lessonService.DeleteAsync(id, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpGet(ApiEndpoints.Lessons.GetById)]
    public async Task<ActionResult<DetailsResponseDto<LessonDto>>> GetById(Guid id,
        CancellationToken cancellationToken = default)
    {
        var response = await _lessonService.GetById(id, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpGet(ApiEndpoints.Lessons.GetAll)]
    public async Task<ActionResult<ListResponseDto<LessonDto>>> GetAll(CancellationToken cancellationToken = default)
    {
        var response = await _lessonService.GetAll(cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
}
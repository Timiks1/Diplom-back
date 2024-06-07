using Microsoft.AspNetCore.Mvc;
using UniversityACS.API.Endpoints;
using UniversityACS.Application.Services.WorkingCurriculumServices;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;

namespace UniversityACS.API.Controllers;

[ApiController]
[Route(ApiEndpoints.WorkingCurriculums.Base)]
public class WorkingCurriculumsController : ControllerBase
{
    private readonly IWorkingCurriculumService _workingCurriculumService;

    public WorkingCurriculumsController(IWorkingCurriculumService workingCurriculumService)
    {
        _workingCurriculumService = workingCurriculumService;
    }

    [HttpPost(ApiEndpoints.WorkingCurriculums.Create)]
    public async Task<ActionResult<CreateResponseDto<WorkingCurriculumResponseDto>>> CreateAsync(WorkingCurriculumDto dto,
        CancellationToken cancellationToken)
    {
        var response = await _workingCurriculumService.CreateAsync(dto, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpPut(ApiEndpoints.WorkingCurriculums.Update)]
    public async Task<ActionResult<UpdateResponseDto<WorkingCurriculumResponseDto>>> UpdateAsync(Guid id,
        WorkingCurriculumDto dto, CancellationToken cancellationToken)
    {
        var response = await _workingCurriculumService.UpdateAsync(id, dto, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpDelete(ApiEndpoints.WorkingCurriculums.Delete)]
    public async Task<ActionResult<ResponseDto>> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var response = await _workingCurriculumService.DeleteAsync(id, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpGet(ApiEndpoints.WorkingCurriculums.GetById)]
    public async Task<ActionResult<DetailsResponseDto<WorkingCurriculumResponseDto>>> GetByIdAsync(Guid id,
        CancellationToken cancellationToken)
    {
        var response = await _workingCurriculumService.GetByIdAsync(id, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpGet(ApiEndpoints.WorkingCurriculums.GetByUserId)]
    public async Task<ActionResult<ListResponseDto<WorkingCurriculumResponseDto>>> GetByUserIdAsync(Guid userId,
        CancellationToken cancellationToken)
    {
        var response = await _workingCurriculumService.GetByUserIdAsync(userId, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpGet(ApiEndpoints.WorkingCurriculums.GetAll)]
    public async Task<ActionResult<ListResponseDto<WorkingCurriculumResponseDto>>> GetAllAsync(
        CancellationToken cancellationToken)
    {
        var response = await _workingCurriculumService.GetAllAsync(cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
    [HttpGet("by-lesson-id")]
    public async Task<ActionResult<ListResponseDto<WorkingCurriculumResponseDto>>> GetByLessonIdAsync(Guid lessonId,
      CancellationToken cancellationToken)
    {
        var response = await _workingCurriculumService.GetByLessonIdAsync(lessonId, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
}
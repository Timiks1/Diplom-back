using Microsoft.AspNetCore.Mvc;
using UniversityACS.API.Endpoints;
using UniversityACS.Application.Services.StudentsGroupServices;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;

namespace UniversityACS.API.Controllers;

[ApiController]
[Route(ApiEndpoints.StudentsGroups.Base)]
public class StudentsGroupsController : ControllerBase
{
    private readonly IStudentsGroupService _studentsGroupService;

    public StudentsGroupsController(IStudentsGroupService studentsGroupService)
    {
        _studentsGroupService = studentsGroupService;
    }

    [HttpPost(ApiEndpoints.StudentsGroups.Create)]
    public async Task<ActionResult<CreateResponseDto<StudentsGroupResponseDto>>> CreateAsync(StudentsGroupDto dto,
        CancellationToken cancellationToken = default)
    {
        var response = await _studentsGroupService.CreateAsync(dto, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpPut(ApiEndpoints.StudentsGroups.Update)]
    public async Task<ActionResult<UpdateResponseDto<StudentsGroupResponseDto>>> UpdateAsync(Guid id,
        StudentsGroupDto dto, CancellationToken cancellationToken = default)
    {
        var response = await _studentsGroupService.UpdateAsync(id, dto, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpDelete(ApiEndpoints.StudentsGroups.Delete)]
    public async Task<ActionResult<ResponseDto>> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var response = await _studentsGroupService.DeleteAsync(id, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpGet(ApiEndpoints.StudentsGroups.GetById)]
    public async Task<ActionResult<DetailsResponseDto<StudentsGroupResponseDto>>> GetByIdAsync(Guid id,
        CancellationToken cancellationToken = default)
    {
        var response = await _studentsGroupService.GetByIdAsync(id, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpGet(ApiEndpoints.StudentsGroups.GetAll)]
    public async Task<ActionResult<ListResponseDto<StudentsGroupResponseDto>>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        var response = await _studentsGroupService.GetAllAsync(cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
}
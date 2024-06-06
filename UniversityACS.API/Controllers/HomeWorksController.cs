using Microsoft.AspNetCore.Mvc;
using UniversityACS.API.Endpoints;
using UniversityACS.Application.Services.HomeWorkServices;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;

namespace UniversityACS.API.Controllers;

[ApiController]
[Route(ApiEndpoints.HomeWorks.Base)]
public class HomeWorksController : ControllerBase
{
    private readonly IHomeWorkService _homeWorkService;

    public HomeWorksController(IHomeWorkService homeWorkService)
    {
        _homeWorkService = homeWorkService;
    }

    [HttpPost(ApiEndpoints.HomeWorks.Create)]
    public async Task<ActionResult<CreateResponseDto<HomeWorkResponseDto>>> CreateAsync(HomeWorkDto dto,
        CancellationToken cancellationToken)
    {
        var response = await _homeWorkService.CreateAsync(dto, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpPut(ApiEndpoints.HomeWorks.Update)]
    public async Task<ActionResult<UpdateResponseDto<HomeWorkResponseDto>>> UpdateAsync(Guid id, HomeWorkDto dto,
        CancellationToken cancellationToken)
    {
        var response = await _homeWorkService.UpdateAsync(id, dto, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpDelete(ApiEndpoints.HomeWorks.Delete)]
    public async Task<ActionResult<ResponseDto>> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var response = await _homeWorkService.DeleteAsync(id, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpGet(ApiEndpoints.HomeWorks.GetById)]
    public async Task<ActionResult<DetailsResponseDto<HomeWorkResponseDto>>> GetByIdAsync(Guid id,
        CancellationToken cancellationToken)
    {
        var response = await _homeWorkService.GetByIdAsync(id, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpGet(ApiEndpoints.HomeWorks.GetAll)]
    public async Task<ActionResult<ListResponseDto<HomeWorkResponseDto>>> GetAllAsync(
        CancellationToken cancellationToken)
    {
        var response = await _homeWorkService.GetAllAsync(cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpPut(ApiEndpoints.HomeWorks.CheckAsync)]
    public async Task<ActionResult<ResponseDto>> CheckAsync(Guid id, bool isChecked,
        CancellationToken cancellationToken)
    {
        var response = await _homeWorkService.CheckAsync(id, isChecked, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpPut(ApiEndpoints.HomeWorks.GradeAsync)]
    public async Task<ActionResult<ResponseDto>> GradeAsync(Guid id, int grade, CancellationToken cancellationToken)
    {
        var response = await _homeWorkService.GradeAsync(id, grade, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
    [HttpGet(ApiEndpoints.HomeWorks.GetByStudentId)]
    public async Task<ActionResult<ListResponseDto<HomeWorkResponseDto>>> GetByStudentIdAsync(Guid studentId, CancellationToken cancellationToken)
    {
        var response = await _homeWorkService.GetByStudentIdAsync(studentId, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
    [HttpPut("update-by-lesson-name")]
    public async Task<ActionResult<ResponseDto>> UpdateByLessonNameAsync([FromQuery] string lessonName, [FromForm] string description, [FromForm] IFormFile file, CancellationToken cancellationToken)
    {
        var response = await _homeWorkService.UpdateByLessonNameAsync(lessonName, description, file, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
    [HttpPut(ApiEndpoints.HomeWorks.AddComment)]
    public async Task<ActionResult<ResponseDto>> AddCommentAsync(Guid id, string comment, CancellationToken cancellationToken)
    {
        var response = await _homeWorkService.AddCommentAsync(id, comment, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

}
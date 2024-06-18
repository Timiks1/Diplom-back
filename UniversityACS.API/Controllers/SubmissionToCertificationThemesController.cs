using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Template;
using UniversityACS.API.Endpoints;
using UniversityACS.Application.Services.SubmissionToCertificationThemesServices;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;
using Xceed.Words.NET;
using Xceed.Document.NET;

namespace UniversityACS.API.Controllers;

[ApiController]
[Route(ApiEndpoints.SubmissionToCertificationThemes.Base)]
public class SubmissionToCertificationThemesController : ControllerBase
{
    private readonly ISubmissionToCertificationThemesService _certificationThemesService;
    private readonly string templatePath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Templates", "Submission.docx");

    public SubmissionToCertificationThemesController(ISubmissionToCertificationThemesService certificationThemesService)
    {
        _certificationThemesService = certificationThemesService;
    }

    [HttpPost(ApiEndpoints.SubmissionToCertificationThemes.Create)]
    public async Task<ActionResult<CreateResponseDto<SubmissionToCertificationThemesResponseDto>>> CreateAsync(
        SubmissionToCertificationThemesDto dto, CancellationToken cancellationToken)
    {
        var response = await _certificationThemesService.CreateAsync(dto, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpPut(ApiEndpoints.SubmissionToCertificationThemes.Update)]
    public async Task<ActionResult<UpdateResponseDto<SubmissionToCertificationThemesResponseDto>>> UpdateAsync(Guid id,
        SubmissionToCertificationThemesDto dto, CancellationToken cancellationToken)
    {
        var response = await _certificationThemesService.UpdateAsync(id, dto, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpDelete(ApiEndpoints.SubmissionToCertificationThemes.Delete)]
    public async Task<ActionResult<ResponseDto>> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var response = await _certificationThemesService.DeleteAsync(id, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpGet(ApiEndpoints.SubmissionToCertificationThemes.GetById)]
    public async Task<ActionResult<DetailsResponseDto<SubmissionToCertificationThemesResponseDto>>> GetByIdAsync(
        Guid id, CancellationToken cancellationToken)
    {
        var response = await _certificationThemesService.GetByIdAsync(id, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpGet(ApiEndpoints.SubmissionToCertificationThemes.GetAll)]
    public async Task<ActionResult<ListResponseDto<SubmissionToCertificationThemesResponseDto>>> GetAllAsync(
        CancellationToken cancellationToken)
    {
        var response = await _certificationThemesService.GetAllAsync(cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
    [HttpPost(ApiEndpoints.SubmissionToCertificationThemes.File)]
    public async Task<ActionResult<ListResponseDto<SubmissionToCertificationThemesResponseDto>>> GetFile(List<string> names,
    CancellationToken cancellationToken)
    {
        using (var memoryStream = new MemoryStream())
        {
            using (var document = DocX.Load(templatePath))
            {
                var table = document.Tables[0];
                for (int i = 0; i < names.Count(); i++)
                {
                    var newRow = table.InsertRow();
                    newRow.Cells[0].Paragraphs[0].InsertText($"{i + 1}");
                    newRow.Cells[0].Paragraphs[0].Font(new Xceed.Document.NET.Font("Times New Roman")).FontSize(12);
                    newRow.Cells[0].Paragraphs[0].Alignment = Alignment.center;
                    newRow.Cells[0].VerticalAlignment = VerticalAlignment.Center;

                    newRow.Cells[3].Paragraphs[0].InsertText(names[i]);
                    newRow.Cells[3].Paragraphs[0].Font(new Xceed.Document.NET.Font("Times New Roman")).FontSize(12);
                    newRow.Cells[3].Paragraphs[0].Alignment = Alignment.center;
                    newRow.Cells[3].VerticalAlignment = VerticalAlignment.Center;
                }

                document.SaveAs(memoryStream);
            }
            SubmissionToCertificationThemesDto dto = new SubmissionToCertificationThemesDto();
            dto.Name = "Подання на затвердження.docx";




            memoryStream.Position = 0;

            var formFile = new FormFile(memoryStream, 0, memoryStream.Length, "file", "Подання на затвердження.docx")
            {
                Headers = new HeaderDictionary(),
                ContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
            };
            dto.File = formFile;
            var response = await _certificationThemesService.CreateAsync(dto, cancellationToken);
            memoryStream.Position = 0;
            if (!response.Success)
                return BadRequest(response);
            return File(memoryStream.ToArray(), "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "Подання на затвердження.docx");
        }
    }
}
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using UniversityACS.API.Endpoints;
using UniversityACS.Application.Mappings;

using UniversityACS.Application.Services.DevelopmentPlanServices;
using UniversityACS.Application.Services.DisciplineServices;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;
using UniversityACS.Core.Entities;
using Xceed.Words.NET;

namespace UniversityACS.API.Controllers;

[ApiController]
[Route(ApiEndpoints.DevelopmentPlans.Base)]
public class DevelopmentPlansController : ControllerBase
{
    private readonly IDevelopmentPlanService _developmentPlanService;
    private readonly IDisciplineService _disciplinesService;
    private readonly string templatePath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Templates", "workPlan.docx");

    public DevelopmentPlansController(IDevelopmentPlanService developmentPlanService, IDisciplineService disciplinesService)
    {
        _developmentPlanService = developmentPlanService;
        _disciplinesService = disciplinesService;
    }

    [HttpPost(ApiEndpoints.DevelopmentPlans.Create)]
    public async Task<ActionResult<CreateResponseDto<DevelopmentPlanResponseDto>>> CreateAsync(DevelopmentPlanDto dto,
        CancellationToken cancellationToken)
    {
        var response = await _developmentPlanService.CreateAsync(dto, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpPut(ApiEndpoints.DevelopmentPlans.Update)]
    public async Task<ActionResult<UpdateResponseDto<DevelopmentPlanResponseDto>>> UpdateAsync(Guid id, DevelopmentPlanDto dto,
        CancellationToken cancellationToken)
    {
        var response = await _developmentPlanService.UpdateAsync(id, dto, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpDelete(ApiEndpoints.DevelopmentPlans.Delete)]
    public async Task<ActionResult<ResponseDto>> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var response = await _developmentPlanService.DeleteAsync(id, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpGet(ApiEndpoints.DevelopmentPlans.GetById)]
    public async Task<ActionResult<DetailsResponseDto<DevelopmentPlanResponseDto>>> GetByIdAsync(Guid id,
        CancellationToken cancellationToken = default)
    {
        var response = await _developmentPlanService.GetByIdAsync(id, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpGet(ApiEndpoints.DevelopmentPlans.GetByUserId)]
    public async Task<ActionResult<ListResponseDto<DevelopmentPlanResponseDto>>> GetByUserIdAsync(
        Guid userId, CancellationToken cancellationToken)
    {
        var response = await _developmentPlanService.GetByUserIdAsync(userId, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpGet(ApiEndpoints.DevelopmentPlans.GetAll)]
    public async Task<ActionResult<ListResponseDto<DevelopmentPlanResponseDto>>> GetAllAsync(
        CancellationToken cancellationToken)
    {
        var response = await _developmentPlanService.GetAllAsync(cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
    [HttpPost(ApiEndpoints.DevelopmentPlans.Upload)]
    public async Task<IActionResult> Upload(IFormFile file,
     CancellationToken cancellationToken = default)
    {

        await _disciplinesService.ClearAsync(cancellationToken);
        if (file == null || file.Length == 0)
            return BadRequest("No file uploaded.");

        using (var stream = new MemoryStream())
        {
            await file.CopyToAsync(stream);
            stream.Position = 0;

            using (var workbook = new XLWorkbook(stream))
            {
                var worksheet = workbook.Worksheet(2);
                for (int i = 11; i <= 75; i++)
                {
                    if (i == 19 || i == 20 || (i > 50 && i < 55) || i == 62 || i == 63)
                    {
                        continue;
                    }
                    Discipline discipline = new Discipline();
                    var mergedRange = worksheet.MergedRanges.FirstOrDefault(range => range.Contains(worksheet.Cell(i, 2)));
                    var currentCell = worksheet.Cell(i, 2);
                    if (mergedRange != null)
                    {
                        currentCell = mergedRange.FirstCell();
                    }
                    discipline.Name = currentCell.Value.ToString();
                    discipline.Exams = worksheet.Cell(i, 9).Value.ToString();
                    discipline.Tests = worksheet.Cell(i, 10).Value.ToString();

                    discipline.ECTS = int.Parse(worksheet.Cell(i, 15).Value.ToString());
                    discipline.LecturerHours = int.Parse(worksheet.Cell(i, 17).Value.ToString());
                    discipline.PracticHours = int.Parse(worksheet.Cell(i, 18).Value.ToString());
                    discipline.LaboratoryHours = int.Parse(worksheet.Cell(i, 19).Value.ToString());
                    discipline.IndependentHours = int.Parse(worksheet.Cell(i, 20).Value.ToString());
                    string temp = "";
                    for (int j = 21; j <= 28; j++)
                    {
                        temp += worksheet.Cell(i, j).Value.ToString() == "" ? "0," : $"{worksheet.Cell(i, j).Value},";
                    }
                    discipline.AuditoryTasks = temp;

                    await _disciplinesService.CreateAsync(discipline.ToDto());

                }

            }
        }

        return Ok("File processed successfully.");
    }


    [HttpPost(ApiEndpoints.DevelopmentPlans.Plan)]
    public async Task<IActionResult> ModifyPdf(int course)
    {
        using (var memoryStream = new MemoryStream())
        {
            using (var document = DocX.Load(templatePath))
            {
                var disciplines = (await this._disciplinesService.GetAllAsync()).Items;

                document.ReplaceText("{PlaceholderCourse}", $"{course}");
                document.ReplaceText("{Semester1}", $"{course * 2 - 1}");
                document.ReplaceText("{Semester2}", $"{course * 2}");
                for (int kk = 1; kk >= 0; kk--)
                {

                    var firstcourse = disciplines.Where(discipline => discipline.Exams.Contains($"{course * 2 - kk}") || discipline.Tests.Contains($"{course * 2 - kk}")).ToList();

                    var table = document.Tables[kk == 0 ? 1 : 0];
                    int? ectsSum = 0;
                    int? LecSum = 0;
                    int? PracSum = 0;
                    int? LabSum = 0;
                    for (int i = kk == 0 ? 2 : 4, j = 0; i < table.RowCount && j < firstcourse.Count; i++, j++)
                    {
                        table.Rows[i].Cells[1].Paragraphs[0].InsertText(firstcourse[j].Name);
                        table.Rows[i].Cells[2].Paragraphs[0].InsertText($"{firstcourse[j].ECTS * 30}");
                        table.Rows[i].Cells[3].Paragraphs[0].InsertText($"{firstcourse[j].ECTS}");
                        table.Rows[i].Cells[4].Paragraphs[0].InsertText($"{firstcourse[j].LecturerHours + firstcourse[j].PracticHours}");
                        table.Rows[i].Cells[5].Paragraphs[0].InsertText($"{firstcourse[j].LecturerHours}");
                        table.Rows[i].Cells[6].Paragraphs[0].InsertText($"{firstcourse[j].PracticHours}");
                        table.Rows[i].Cells[7].Paragraphs[0].InsertText($"{firstcourse[j].LaboratoryHours}");
                        var elem = firstcourse[j].Exams == "" ? "зал" : "екз";
                        table.Rows[i].Cells[9].Paragraphs[0].InsertText($"{elem}");

                        ectsSum += firstcourse[j].ECTS;
                        LecSum += firstcourse[j].LecturerHours;
                        PracSum += firstcourse[j].PracticHours;
                        LabSum += firstcourse[j].LaboratoryHours;

                        table.Rows[i].Cells.ForEach(x => x.Paragraphs[0].Font(new Xceed.Document.NET.Font("Times New Roman")).FontSize(10.5f));
                    }
                    table.Rows[table.RowCount - 1 - (kk == 0 ? 4 : 0)].Cells.ForEach(x => x.Paragraphs[0].Font(new Xceed.Document.NET.Font("Times New Roman")).FontSize(10.5f));
                    table.Rows[table.RowCount - 1 - (kk == 0 ? 4 : 0)].Cells[2].Paragraphs[0].InsertText($"{ectsSum * 30}");
                    table.Rows[table.RowCount - 1 - (kk == 0 ? 4 : 0)].Cells[3].Paragraphs[0].InsertText($"{ectsSum}");
                    table.Rows[table.RowCount - 1 - (kk == 0 ? 4 : 0)].Cells[4].Paragraphs[0].InsertText($"{LecSum + PracSum}");
                    table.Rows[table.RowCount - 1 - (kk == 0 ? 4 : 0)].Cells[5].Paragraphs[0].InsertText($"{LecSum}");
                    table.Rows[table.RowCount - 1 - (kk == 0 ? 4 : 0)].Cells[6].Paragraphs[0].InsertText($"{PracSum}");
                    table.Rows[table.RowCount - 1 - (kk == 0 ? 4 : 0)].Cells[7].Paragraphs[0].InsertText($"{LabSum}");
                    table.Rows[table.RowCount - 1 - (kk == 0 ? 4 : 0)].Cells.ForEach(x => x.Paragraphs[0].Font(new Xceed.Document.NET.Font("Times New Roman")).FontSize(10.5f));
                }
                document.SaveAs(memoryStream);
            }
            return File(memoryStream.ToArray(), "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "ModifiedPlan.docx");
        }
    }

}
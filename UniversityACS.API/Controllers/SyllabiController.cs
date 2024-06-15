using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Template;
using System.IO.Compression;
using System.IO;
using UniversityACS.API.Endpoints;
using UniversityACS.Application.Services.DisciplineServices;
using UniversityACS.Application.Services.SyllabusServices;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.Entities;
using Xceed.Document.NET;
using Xceed.Words.NET;
using System.Reflection.Metadata;
using Aspose.Pdf.Operators;
using iText.IO.Source;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Packaging;
using Run = DocumentFormat.OpenXml.Wordprocessing.Run;

namespace UniversityACS.API.Controllers;

[ApiController]
[Route(ApiEndpoints.Syllabi.Base)]
public class SyllabiController : ControllerBase
{
    private readonly ISyllabusService _syllabusService;
    private readonly IDisciplineService _disciplinesService;
    private readonly string templatePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates", "Syllabi.docx");


    public SyllabiController(ISyllabusService syllabusService, IDisciplineService disciplinesService)
    {
        _syllabusService = syllabusService;
        _disciplinesService = disciplinesService;
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
    [HttpPost(ApiEndpoints.Syllabi.Generate)]
    public async Task<IActionResult> GenerateSyllabus([FromQuery] Guid disciplineId, [FromQuery] Guid teacherId, CancellationToken cancellationToken)
    {

        var discipline = (await _disciplinesService.GetByIdAsync(disciplineId)).Item;
        try
        {
            if (!System.IO.File.Exists(templatePath))
                return NotFound(new { ErrorMessage = "Template file not found.", StatusCode = 404 });
            if (discipline.Exams.Contains(",") || discipline.Tests.Contains(","))
            {
                using (var memoryStream = new MemoryStream())
                {
                    using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            double course = 0, semester = 0;
                            if (discipline.Exams == "")
                            {
                                semester = double.Parse(discipline.Tests.Split(",")[i]);
                            }
                            else
                            {
                                semester = double.Parse(discipline.Exams.Split(",")[i]);
                            }
                            course = Math.Ceiling(semester / 2.0);

                            using (var document = DocX.Load(templatePath))
                            {
                                double hours = (double)(discipline.IndependentHours + discipline.LecturerHours + discipline.PracticHours);

                                document.ReplaceText("{Name}", $"{discipline.Name.ToUpper()} (Ч.{i + 1})");
                                document.ReplaceText("{Course}", course.ToString());
                                document.ReplaceText("{Semester}", semester.ToString());
                                document.ReplaceText("{ECTS}", discipline.ECTS.ToString());
                                document.ReplaceText("{Hours}", hours.ToString());
                                document.ReplaceText("{Lections}", discipline.LecturerHours.ToString());
                                document.ReplaceText("{Practics}", discipline.PracticHours.ToString());
                                document.ReplaceText("{Independent}", discipline.IndependentHours.ToString());
                                document.ReplaceText("{SemestryControl}", discipline.Exams == "" ? "Залік" : "Екзамен");
                                document.ReplaceText("{mod1}", $"{Math.Round((double)(discipline.ECTS * 10 / hours * 100)) / 100}");
                                document.ReplaceText("{mod2}", $"{Math.Round((double)discipline.PracticHours / hours * 100) / 100}");
                                document.ReplaceText("{mod3}", $"{Math.Round((double)discipline.IndependentHours / hours * 100) / 100}");

                                var entry1 = archive.CreateEntry($"{discipline.Name} (Ч.{i + 1}) (Силабус скорочений).docx");
                                using (var entryStream = entry1.Open())
                                {
                                    using (var tempStream = new MemoryStream())
                                    {
                                        document.SaveAs(tempStream);
                                        tempStream.Position = 0;
                                        tempStream.CopyTo(entryStream);

                                        SyllabusDto syllabusDto = new SyllabusDto();
                                        syllabusDto.Name = $"{discipline.Name} (Ч.{i + 1})";
                                        syllabusDto.TeacherId = teacherId;


                                        tempStream.Position = 0;

                                        var formFile = new FormFile(tempStream, 0, tempStream.Length, "file", $"{discipline.Name} (Силабус скорочений).docx")
                                        {
                                            Headers = new HeaderDictionary(),
                                            ContentType = "application/zip"
                                        };
                                        syllabusDto.File = formFile;
                                        var response = await _syllabusService.CreateAsync(syllabusDto, cancellationToken);
                                        if (!response.Success)
                                        {
                                            return BadRequest(response);
                                        }
                                    }
                                }
                            }
                        }

                    }

                    memoryStream.Position = 0;
                    return File(memoryStream.ToArray(), "application/zip", $"{discipline.Name} (Силабуси).zip");
                }

            }
            else
            {
                using (var document = DocX.Load(templatePath))
                {
                    double course = 0, semester = 0;
                    if (discipline.Exams == "")
                    {
                        semester = double.Parse(discipline.Tests);
                    }
                    else
                    {
                        semester = double.Parse(discipline.Exams);
                    }
                    course = Math.Ceiling(semester / 2.0);

                    double hours = (double)(discipline.IndependentHours + discipline.LecturerHours + discipline.PracticHours);
                    document.ReplaceText("{Name}", discipline.Name.ToUpper());
                    document.ReplaceText("{Course}", course.ToString());
                    document.ReplaceText("{Semester}", semester.ToString());
                    document.ReplaceText("{ECTS}", discipline.ECTS.ToString());
                    document.ReplaceText("{Hours}", hours.ToString());
                    document.ReplaceText("{Lections}", discipline.LecturerHours.ToString());
                    document.ReplaceText("{Practics}", discipline.PracticHours.ToString());
                    document.ReplaceText("{Independent}", discipline.IndependentHours.ToString());
                    document.ReplaceText("{SemestryControl}", discipline.Exams == "" ? "Залік" : "Екзамен");
                    document.ReplaceText("{mod1}", $"{Math.Round((double)(discipline.ECTS * 10 / hours * 100)) / 100}");
                    document.ReplaceText("{mod2}", $"{Math.Round((double)discipline.PracticHours / hours * 100) / 100}");
                    document.ReplaceText("{mod3}", $"{Math.Round((double)discipline.IndependentHours / hours * 100) / 100}");


                    SyllabusDto syllabusDto = new SyllabusDto();
                    syllabusDto.Name = discipline.Name.ToUpper();
                    syllabusDto.TeacherId = teacherId;
                    syllabusDto.Id = Guid.NewGuid();

                    using (var memoryStream = new MemoryStream())
                    {
                        document.SaveAs(memoryStream);
                        memoryStream.Position = 0;

                        var formFile = new FormFile(memoryStream, 0, memoryStream.Length, "file", $"{discipline.Name} (Силабус скорочений).docx")
                        {
                            Headers = new HeaderDictionary(),
                            ContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                        };
                        syllabusDto.File = formFile;
                        var response = await _syllabusService.CreateAsync(syllabusDto, cancellationToken);
                        if (!response.Success)
                        {
                            return BadRequest(response);
                        }
                        memoryStream.Position = 0;
                        return Ok(new
                        {
                            file = memoryStream.ToArray(),
                            fileName = $"{discipline.Name} - {syllabusDto.Id} (Силабус скорочений).docx",
                            syllabusId = syllabusDto.Id
                        });
                    }

                }
            }

        }
        catch (Exception ex)
        {
            return StatusCode(500, new { ErrorMessage = "An unexpected error occurred.", StatusCode = 500, Element = ex.Message });
        }

    }
    [HttpPost(ApiEndpoints.Syllabi.UpdateWithData)]
    public async Task<IActionResult> UpdateSyllabusWithData(Guid syllabusId, [FromBody] SyllabusDataDto syllabusDataDto, CancellationToken cancellationToken)
    {
        var syllabusResponse = await _syllabusService.GetByIdAsync(syllabusId, cancellationToken);

        if (syllabusResponse == null || !syllabusResponse.Success)
        {
            return NotFound(new { ErrorMessage = "Syllabus not found.", StatusCode = 404 });
        }

        var syllabus = syllabusResponse.Item;

        if (syllabus.File == null || syllabus.File.Length == 0)
        {
            return NotFound(new { ErrorMessage = "Syllabus file not found.", StatusCode = 404 });
        }

        try
        {
            using (var memoryStream = new MemoryStream())
            {
                memoryStream.Write(syllabus.File, 0, syllabus.File.Length);
                memoryStream.Position = 0;

                using (var document = WordprocessingDocument.Open(memoryStream, true))
                {
                    var body = document.MainDocumentPart.Document.Body;
                    UpdateDocument(body, syllabusDataDto);
                    document.MainDocumentPart.Document.Save();
                }

                var updatedFileBytes = memoryStream.ToArray();

                var updatedSyllabusDto = new SyllabusDto
                {
                    Id = syllabusId,
                    Name = syllabus.Name,
                    TeacherId = syllabus.TeacherId,
                    File = new FormFile(new MemoryStream(updatedFileBytes), 0, updatedFileBytes.Length, "file", $"{syllabusId}.docx")
                };

                var updateResponse = await _syllabusService.UpdateAsync(syllabusId, updatedSyllabusDto, cancellationToken);

                if (!updateResponse.Success)
                {
                    return BadRequest(updateResponse);
                }

                return Ok(new
                {
                    file = updatedFileBytes,
                    syllabusId = syllabusId
                });
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { ErrorMessage = "An unexpected error occurred.", StatusCode = 500, Element = ex.Message });
        }
    }
    private void UpdateDocument(Body body, SyllabusDataDto data)
    {
        ReplaceText(body, "{literature}", data.Literature);
        ReplaceText(body, "{additionalInfo}", data.AdditionalInfo);
        ReplaceText(body, "{teacherInfo}", data.TeacherInfo);
        ReplaceText(body, "{prerequisites}", data.Prerequisites);
        ReplaceText(body, "{corequisites}", data.Corequisites);
        ReplaceText(body, "{disciplineGoal}", data.DisciplineGoal);
        ReplaceText(body, "{disciplineContent}", data.DisciplineContent);
        ReplaceText(body, "{individualTasks}", data.IndividualTasks);
        ReplaceText(body, "{software}", data.Software);
        ReplaceText(body, "{studyResults}", data.StudyResults);
    }

    private void ReplaceText(Body body, string placeholder, string text)
    {
        var paragraphs = body.Descendants<DocumentFormat.OpenXml.Wordprocessing.Paragraph>().ToList();

        foreach (var paragraph in paragraphs)
        {
            var runs = paragraph.Descendants<Run>().ToList();
            string paragraphText = string.Join("", runs.SelectMany(run => run.Elements<Text>()).Select(t => t.Text));

            if (paragraphText.Contains(placeholder))
            {
                paragraphText = paragraphText.Replace(placeholder, text);

                // Удаление всех Run элементов и создание нового с обновленным текстом
                paragraph.RemoveAllChildren<Run>();

                var newRun = new Run();
                newRun.AppendChild(new Text(paragraphText));
                paragraph.AppendChild(newRun);
            }
        }
    }



    [HttpGet("download/{syllabusId}")]
    public async Task<IActionResult> DownloadSyllabusFile(Guid syllabusId, CancellationToken cancellationToken)
    {
        var syllabusResponse = await _syllabusService.GetByIdAsync(syllabusId, cancellationToken);

        if (syllabusResponse == null || !syllabusResponse.Success)
        {
            return NotFound(new { ErrorMessage = "Syllabus not found.", StatusCode = 404 });
        }

        var syllabus = syllabusResponse.Item;

        if (syllabus.File == null || syllabus.File.Length == 0)
        {
            return NotFound(new { ErrorMessage = "Syllabus file not found.", StatusCode = 404 });
        }

        return File(syllabus.File, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", $"{syllabus.Name}.docx");
    }

}


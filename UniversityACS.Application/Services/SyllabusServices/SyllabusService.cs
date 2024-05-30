using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.EntityFrameworkCore;
using UniversityACS.Application.Mappings;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;
using UniversityACS.Core.Entities;
using UniversityACS.Data.DataContext;

using Word = DocumentFormat.OpenXml.Wordprocessing;

namespace UniversityACS.Application.Services.SyllabusServices;

public class SyllabusService : ISyllabusService
{
    private readonly ApplicationDbContext _context;

    public SyllabusService(ApplicationDbContext context)
    {
        _context = context;

    }

    public async Task<CreateResponseDto<SyllabusDto>> CreateAsync(SyllabusDto dto, CancellationToken cancellationToken)
    {
        var syllabus = dto.ToEntity();

        if (dto.File != null)
        {
            using var memoryStream = new MemoryStream();
            await dto.File.CopyToAsync(memoryStream, cancellationToken);
            syllabus.File = memoryStream.ToArray();
        }

        await _context.Syllabi.AddAsync(syllabus, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new CreateResponseDto<SyllabusDto>
        {
            Success = true,
            Id = syllabus.Id
        };
    }

    public async Task<UpdateResponseDto<SyllabusDto>> UpdateAsync(Guid id, SyllabusDto dto, CancellationToken cancellationToken)
    {
        var existingSyllabus = await _context.Syllabi
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (existingSyllabus == null)
        {
            return new UpdateResponseDto<SyllabusDto>
            {
                Success = false,
                ErrorMessage = "Syllabus not found"
            };
        }

        existingSyllabus.UpdateEntity(dto);
        if (dto.File != null)
        {
            using var memoryStream = new MemoryStream();
            await dto.File.CopyToAsync(memoryStream, cancellationToken);
            existingSyllabus.File = memoryStream.ToArray();
        }

        _context.Syllabi.Update(existingSyllabus);
        await _context.SaveChangesAsync(cancellationToken);

        return new UpdateResponseDto<SyllabusDto>
        {
            Success = true,
            Id = existingSyllabus.Id
        };
    }

    public async Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var existingSyllabus = await _context.Syllabi
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (existingSyllabus == null)
        {
            return new ResponseDto()
            {
                Success = false,
                ErrorMessage = "Syllabus not found"
            };
        }

        _context.Syllabi.Remove(existingSyllabus);
        await _context.SaveChangesAsync(cancellationToken);

        return new ResponseDto() { Success = true };
    }

    public async Task<DetailsResponseDto<SyllabusResponseDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var existingSyllabus = await _context.Syllabi
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (existingSyllabus == null)
        {
            return new DetailsResponseDto<SyllabusResponseDto>
            {
                Success = false,
                ErrorMessage = "Syllabus not found"
            };
        }

        return new DetailsResponseDto<SyllabusResponseDto>
        {
            Success = true,
            Item = existingSyllabus.ToDto()
        };
    }

    public async Task<ListResponseDto<SyllabusResponseDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var syllabi = await _context.Syllabi
            .ToListAsync(cancellationToken);

        return new ListResponseDto<SyllabusResponseDto>()
        {
            Items = syllabi.Select(x => x.ToDto()).ToList(),
            TotalCount = syllabi.Count,
            Success = true
        };
    }

    public async Task<ListResponseDto<SyllabusResponseDto>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        var syllabi = await _context.Syllabi
            .Where(x => x.TeacherId == userId)
            .ToListAsync(cancellationToken);

        return new ListResponseDto<SyllabusResponseDto>()
        {
            Items = syllabi.Select(x => x.ToDto()).ToList(),
            TotalCount = syllabi.Count,
            Success = true
        };
    }

    public async Task<Guid> CreateSyllabusFromJsonAsync(SyllabusFileDto syllabusDto, Guid teacherId, string fileName, CancellationToken cancellationToken)
    {
        var syllabus = new Syllabus
        {
            Id = Guid.NewGuid(),
            TeacherId = teacherId,
            Name = fileName,
        };

        // Создание Word документа
        var filePath = Path.Combine(Path.GetTempPath(), $"{syllabus.Name}.docx");

        using (var wordDocument = WordprocessingDocument.Create(filePath, DocumentFormat.OpenXml.WordprocessingDocumentType.Document))
        {
            var mainPart = wordDocument.AddMainDocumentPart();
            mainPart.Document = new Word.Document();
            var body = new Word.Body();
            mainPart.Document.Append(body);

            var titleParagraph = new Word.Paragraph(new Word.Run(new Word.Text("Силлабус"))
            {
                RunProperties = new Word.RunProperties(new Word.Bold(), new Word.FontSize { Val = "40" })
            });
            body.AppendChild(titleParagraph);

            body.AppendChild(new Word.Paragraph(new Word.Run(new Word.Text($"Ступінь вищої освіти: {syllabusDto.Degree}"))));
            body.AppendChild(new Word.Paragraph(new Word.Run(new Word.Text($"Рівень вищої освіти: {syllabusDto.EducationLevel}"))));
            body.AppendChild(new Word.Paragraph(new Word.Run(new Word.Text($"Галузь знань: {syllabusDto.KnowledgeArea}"))));
            body.AppendChild(new Word.Paragraph(new Word.Run(new Word.Text($"Спеціальність: {syllabusDto.Specialty}"))));
            body.AppendChild(new Word.Paragraph(new Word.Run(new Word.Text($"Освітньо-професійна програма (ОПП): {syllabusDto.Opp}"))));
            body.AppendChild(new Word.Paragraph(new Word.Run(new Word.Text($"Статус дисципліни: {syllabusDto.DisciplineStatus}"))));
            body.AppendChild(new Word.Paragraph(new Word.Run(new Word.Text($"Курс та семестр: {syllabusDto.CourseAndSemester}"))));
            body.AppendChild(new Word.Paragraph(new Word.Run(new Word.Text($"Обсяг дисципліни: {syllabusDto.DisciplineVolume}"))));
            body.AppendChild(new Word.Paragraph(new Word.Run(new Word.Text($"Мова викладання: {syllabusDto.TeachingLanguage}"))));
            body.AppendChild(new Word.Paragraph(new Word.Run(new Word.Text($"Література: {syllabusDto.Literature}"))));
            body.AppendChild(new Word.Paragraph(new Word.Run(new Word.Text($"Додаткова інформація: {syllabusDto.AdditionalInfo}"))));
            body.AppendChild(new Word.Paragraph(new Word.Run(new Word.Text($"Кафедра: {syllabusDto.Department}"))));
            body.AppendChild(new Word.Paragraph(new Word.Run(new Word.Text($"Інформація про викладача: {syllabusDto.TeacherInfo}"))));
            body.AppendChild(new Word.Paragraph(new Word.Run(new Word.Text($"Пререквізити: {syllabusDto.Prerequisites}"))));
            body.AppendChild(new Word.Paragraph(new Word.Run(new Word.Text($"Пореквізити: {syllabusDto.Corequisites}"))));
            body.AppendChild(new Word.Paragraph(new Word.Run(new Word.Text($"Мета навчальної дисципліни: {syllabusDto.DisciplineGoal}"))));
            body.AppendChild(new Word.Paragraph(new Word.Run(new Word.Text($"Зміст дисципліни: {syllabusDto.DisciplineContent}"))));
            body.AppendChild(new Word.Paragraph(new Word.Run(new Word.Text($"Індивідуальні завдання: {syllabusDto.IndividualTasks}"))));
            body.AppendChild(new Word.Paragraph(new Word.Run(new Word.Text($"Програмне забезпечення: {syllabusDto.Software}"))));
            body.AppendChild(new Word.Paragraph(new Word.Run(new Word.Text($"Результати вивчення: {syllabusDto.StudyResults}"))));
            body.AppendChild(new Word.Paragraph(new Word.Run(new Word.Text($"Політика навчальної дисципліни: {syllabusDto.DisciplinePolicy}"))));

            wordDocument.MainDocumentPart.Document.Save();
        }

        syllabus.File = await File.ReadAllBytesAsync(filePath, cancellationToken);

        _context.Syllabi.Add(syllabus);
        await _context.SaveChangesAsync(cancellationToken);

        return syllabus.Id;
    }
}
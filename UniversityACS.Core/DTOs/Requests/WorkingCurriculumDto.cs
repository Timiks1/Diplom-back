using Microsoft.AspNetCore.Http;

namespace UniversityACS.Core.DTOs.Requests;

public class WorkingCurriculumDto
{
    public Guid Id { get; set; }

    public Guid? TeacherId { get; set; }

    public string? Name { get; set; }
    public IFormFile? File { get; set; }
    public Guid LessonId { get; set; } // новое поле
    public string FileFormat { get; set; } = string.Empty; // новое поле
}
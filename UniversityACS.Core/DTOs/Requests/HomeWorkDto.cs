using Microsoft.AspNetCore.Http;

namespace UniversityACS.Core.DTOs.Requests;

public class HomeWorkDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? Comment { get; set; }
    public string? Answer { get; set; }
    public IFormFile? File { get; set; }
    public bool IsChecked { get; set; }
    public int Grade { get; set; }

    public Guid? StudentId { get; set; }

    public Guid? DisciplineId { get; set; }
    public Guid? TeacherId { get; set; }
}
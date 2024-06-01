namespace UniversityACS.Core.DTOs.Responses;

public class HomeWorkResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? Comment { get; set; }
    public string? Answer { get; set; }
    public string? StudentName { get; set; }
    public string? TeacherName { get; set; }
    public string? DisciplineName { get; set; }
    public byte[]? File { get; set; }
    public bool IsChecked { get; set; }
    public int Grade { get; set; }

    public Guid? StudentId { get; set; }

    public Guid? DisciplineId { get; set; }
    public Guid? TeacherId { get; set; }
}
namespace UniversityACS.Core.Entities;

public class WorkingCurriculum
{
    public Guid Id { get; set; }

    public Guid? TeacherId { get; set; }
    public ApplicationUser? Teacher { get; set; }

    public string? Name { get; set; }
    public byte[]? File { get; set; }

    public Guid LessonId { get; set; } // новое поле
    public string FileFormat { get; set; } = string.Empty; // новое поле
}
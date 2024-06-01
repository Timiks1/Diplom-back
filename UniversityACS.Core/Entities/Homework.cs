namespace UniversityACS.Core.Entities;

public class HomeWork
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? Comment { get; set; }
    public string? Answer { get; set; }
    public byte[]? File { get; set; }
    public bool IsChecked { get; set; }
    public int Grade { get; set; }

    public Guid? DisciplineId { get; set; }
    public Discipline? Discipline { get; set; }

    public Guid? StudentId { get; set; }
    public ApplicationUser? Student { get; set; }

    public Guid? TeacherId { get; set; }
    public ApplicationUser? Teacher { get; set; }
}
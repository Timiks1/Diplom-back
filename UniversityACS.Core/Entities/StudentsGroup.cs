namespace UniversityACS.Core.Entities;

public class StudentsGroup
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public List<ApplicationUser>? Students { get; set; }
    public List<Discipline>? Disciplines { get; set; }

}
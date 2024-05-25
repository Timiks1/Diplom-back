namespace UniversityACS.Core.Entities;

public class Schedule
{
    public Guid Id { get; set; }

    public Guid? DepartmentId { get; set; }
    public Department? Department { get; set; }

    public string? Name { get; set; }
    public byte[]? File { get; set; }
    // Новое поле

}
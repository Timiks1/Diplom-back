﻿namespace UniversityACS.Core.DTOs.Requests;

public class DisciplineDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? FieldOfStudy { get; set; }
    public string? Description { get; set; }
    public List<string>? Courses { get; set; }
}
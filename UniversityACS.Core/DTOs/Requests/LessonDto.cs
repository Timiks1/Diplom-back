namespace UniversityACS.Core.DTOs.Requests;

public class LessonDto
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public string? SubjectName { get; set; }
    public string? LessonName { get; set; }
    public Guid TeacherId { get; set; }
    public Guid? HomeWorkId { get; set; }

    public List<StudentAttendanceDto>? StudentAttendances { get; set; }
}
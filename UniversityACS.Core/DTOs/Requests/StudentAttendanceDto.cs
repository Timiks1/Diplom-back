namespace UniversityACS.Core.DTOs.Requests;

public class StudentAttendanceDto
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public bool IsPresent { get; set; }
    public bool IsLate { get; set; }
    public int Grade { get; set; }
    public Guid LessonId { get; set; }
}
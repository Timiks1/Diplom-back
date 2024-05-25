using Microsoft.AspNetCore.Http;
using UniversityACS.Core.Entities;

namespace UniversityACS.Core.DTOs.Requests
{
    public class ScheduleDto
    {
        public Guid Id { get; set; }
        public Guid? DepartmentId { get; set; }
        public string? Name { get; set; }
        public IFormFile? File { get; set; }
        public Guid TeacherId { get; set; }
        public DateTime Date { get; set; }
        public string Lesson { get; set; }
        public string Teacher { get; set; }
        public TimeSpan Time { get; set; }
        public string Description { get; set; }
        public string GroupName { get; set; }  // Новое свойство
    }
}

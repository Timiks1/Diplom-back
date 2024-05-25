using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityACS.Core.Entities;
using UniversityACS.Data.DataContext;

namespace UniversityACS.Application.Services.AttendanceServices
{
    public class AttendanceService : IAttendanceService
    {
        private readonly ApplicationDbContext _context;
        public AttendanceService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(Lesson lesson)
        {
            if (lesson == null)
            {
                throw new ArgumentNullException(nameof(lesson));
            }

            lesson.Id = Guid.NewGuid(); // Генерация нового идентификатора для урока
            foreach (var student in lesson.StudentAttendances)
            {
                student.Id = Guid.NewGuid(); // Генерация нового идентификатора для каждого присутствия студента
            }

            _context.Lessons.Add(lesson);
            await _context.SaveChangesAsync();
        }
    }
}

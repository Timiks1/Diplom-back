using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityACS.Core.Entities
{
    public class StudentAttendance
    {
        public Guid Id { get; set; }
        public string StudentName { get; set; }
        public bool IsPresent { get; set; }
        public int Grade { get; set; }
        public Guid LessonId { get; set; }
        public Lesson Lesson { get; set; }
    }
}

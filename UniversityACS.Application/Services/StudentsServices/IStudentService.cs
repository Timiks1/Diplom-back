using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityACS.Core.Entities;

namespace UniversityACS.Application.Services.StudentsServices
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<Student> GetStudentByIdAsync(Guid id);
        Task<Student> CreateStudentAsync(Student student);
        Task UpdateStudentAsync(Guid id, Student student);
        Task DeleteStudentAsync(Guid id);

        Task<IEnumerable<Student>> GetStudentsByGroupAsync(Guid groupId);

    }
}

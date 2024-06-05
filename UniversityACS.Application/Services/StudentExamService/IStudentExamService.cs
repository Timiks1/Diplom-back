using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityACS.Core.DTOs.Requests;

namespace UniversityACS.Application.Services.StudentExamService
{
    public interface IStudentExamService
    {
        Task<StudentExamDto> CreateAsync(StudentExamDto dto, CancellationToken cancellationToken = default);
        Task<StudentExamDto> UpdateAsync(Guid id, StudentExamDto dto, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<StudentExamDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<StudentExamDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<List<StudentExamDto>> GetByDisciplineIdAsync(Guid disciplineId, CancellationToken cancellationToken = default); // Новый метод

    }
}

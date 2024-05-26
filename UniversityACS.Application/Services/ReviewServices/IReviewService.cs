using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityACS.Core.Entities;

namespace UniversityACS.Application.Services.ReviewServices
{
    public interface IReviewService
    {
        Task<Review> AddReviewAsync(Review review);
        Task<List<Review>> GetReviewsByStudentIdAsync(Guid studentId);
        Task<List<Review>> GetReviewsByTeacherIdAsync(Guid teacherId);
    }
}

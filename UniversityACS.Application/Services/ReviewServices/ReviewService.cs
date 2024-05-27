using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityACS.Core.Entities;
using UniversityACS.Data.DataContext;
using Microsoft.EntityFrameworkCore;
namespace UniversityACS.Application.Services.ReviewServices
{
    public class ReviewService : IReviewService
    {
        private readonly ApplicationDbContext _context;

        public ReviewService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Review> AddReviewAsync(Review review)
        {
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
            return review;
        }

        public async Task<List<Review>> GetReviewsByStudentIdAsync(Guid studentId)
        {
            return await _context.Reviews.Where(r => r.StudentId == studentId).ToListAsync();
        }

        public async Task<List<Review>> GetReviewsByTeacherIdAsync(Guid teacherId)
        {
            return await _context.Reviews.Where(r => r.TeacherId == teacherId).ToListAsync();
        }
    }
}

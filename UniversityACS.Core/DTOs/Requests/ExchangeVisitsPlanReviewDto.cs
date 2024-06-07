using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityACS.Core.DTOs.Requests
{
    public class ExchangeVisitsPlanReviewDto
    {
        public Guid Id { get; set; }
        public Guid? TeacherId { get; set; }
        public Guid ExchangeVisitsPlan { get; set; }
        public string? Name { get; set; }
        public IFormFile? File { get; set; }
    }
}

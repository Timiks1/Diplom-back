using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityACS.Core.DTOs.Responses
{
    public class ExchangeVisitsPlanReviewResponseDto
    {
        public Guid Id { get; set; }
        public Guid? TeacherId { get; set; }
        public Guid ExchangeVisitsPlan { get; set; }
        public string? Name { get; set; }
        public byte[]? File { get; set; }
    }
}

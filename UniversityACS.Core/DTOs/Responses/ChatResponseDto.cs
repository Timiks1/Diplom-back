using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityACS.Core.Entities;

namespace UniversityACS.Core.DTOs.Responses
{
    public class ChatResponseDto
    {
        public Guid Id { get; set; }
        public string Message { get; set; } = string.Empty;
        public Guid? TeacherId { get; set; }
        public DateTime? TimeCreation { get; set; }
        public ApplicationUser? Teacher { get; set; }
    }
}

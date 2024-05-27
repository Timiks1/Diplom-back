using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityACS.Core.Entities
{
    public class Review
    {
        public Guid Id { get; set; }
        public Guid TeacherId { get; set; }
        public Guid StudentId { get; set; }
        public DateTime Date { get; set; }
        public string Discipline { get; set; }
        public string Comment { get; set; }
    }
}

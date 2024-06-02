using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityACS.Core.Entities
{
    public class Student
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }
        public Guid GroupId { get; set; }
        public Group Group { get; set; }
        public List<Review> Reviews { get; set; } = new List<Review>();
    }
}

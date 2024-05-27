using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityACS.Core.Entities
{
    public class Group
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; } = new List<Student>();
        public ICollection<ApplicationUser> Teachers { get; set; } = new List<ApplicationUser>();

    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityACS.Core.Entities;

namespace UniversityACS.Application.Services.AttendanceServices
{
    public interface IAttendanceService
    {
        Task Create(Lesson lesson);

    }
}

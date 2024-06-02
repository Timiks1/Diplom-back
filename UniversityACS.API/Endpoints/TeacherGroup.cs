using UniversityACS.API.Endpoints;

namespace UniversityACS.API.Endpoints
{
    public static partial class ApiEndpoints
    {
        public static class TeacherGroup
        {
            public const string Base = "api/studentsgroups";
            public const string AddTeacherToGroup = "add-teacher";
            public const string RemoveTeacherFromGroup = "remove-teacher";
        }
    }
}

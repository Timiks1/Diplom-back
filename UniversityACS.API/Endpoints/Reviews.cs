namespace UniversityACS.API.Endpoints
{
    public static partial class ApiEndpoints
    {
        public static class Reviews
        {
            public const string Base = $"{BaseApiEndpoint}/{nameof(Reviews)}";

            public const string Create = Base;
            public const string GetByStudentId = $"{Base}/ByStudent/{{studentId:guid}}";
            public const string GetByTeacherId = $"{Base}/ByTeacher/{{teacherId:guid}}";
        }
    }

}

namespace UniversityACS.API.Endpoints;

public static partial class ApiEndpoints
{
    public static class StudentAttendances
    {
        public const string Base = $"{BaseApiEndpoint}/{nameof(StudentAttendances)}";

        public const string Create = Base;
        public const string Delete = $"{Base}/{{id:guid}}";
        public const string Update = $"{Base}/{{id:guid}}";
        public const string GetById = $"{Base}/{{id:guid}}";
        public const string GetAll = Base;
        public const string GetByStudentId = $"{Base}/{nameof(GetByStudentId)}/{{studentId:guid}}";
    }
}
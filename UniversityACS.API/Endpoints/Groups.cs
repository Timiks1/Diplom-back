namespace UniversityACS.API.Endpoints
{
    public static partial class ApiEndpoints
    {
        public static class Groups
        {
            public const string Base = "api/groups";
            public const string Create = Base;
            public const string Delete = $"{Base}/{{id:guid}}";
            public const string Update = $"{Base}/{{id:guid}}";
            public const string GetById = $"{Base}/{{id:guid}}";
            public const string GetAll = Base;
            public const string AddTeacher = $"{Base}/{{groupId:guid}}/addTeacher/{{teacherId:guid}}";
            public const string RemoveTeacher = $"{Base}/{{groupId:guid}}/removeTeacher/{{teacherId:guid}}";
        }
    }
}

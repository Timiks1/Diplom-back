namespace UniversityACS.API.Endpoints
{
    public static partial class ApiEndpoints
    {
        public static class Students
        {
            public const string Base = $"{BaseApiEndpoint}/{nameof(Students)}";

            public const string Create = Base;
            public const string Delete = $"{Base}/{{id:guid}}";
            public const string Update = $"{Base}/{{id:guid}}";
            public const string GetById = $"{Base}/{{id:guid}}";
            public const string GetAll = Base;
            public const string GetByGroup = $"{Base}/byGroup";
        }
    }

}

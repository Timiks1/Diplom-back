namespace UniversityACS.API.Endpoints;

public static partial class ApiEndpoints
{
    public static class HomeWorks
    {
        public const string Base = $"{BaseApiEndpoint}/{nameof(HomeWorks)}";

        public const string Create = Base;
        public const string Delete = $"{Base}/{{id:guid}}";
        public const string Update = $"{Base}/{{id:guid}}";
        public const string GetById = $"{Base}/{{id:guid}}";
        public const string GetAll = Base;
        public const string CheckAsync = $"{Base}/{nameof(CheckAsync)}/{{id:guid}}/{{isChecked:bool}}";
        public const string GradeAsync = $"{Base}/{nameof(GradeAsync)}/{{id:guid}}/{{grade:int}}";
        public const string GetByStudentIdDisciplineIdAsync = $"{Base}/{nameof(GetByStudentIdDisciplineIdAsync)}/{{studentId:guid}}/{{disciplineId:guid}}";
    }
}
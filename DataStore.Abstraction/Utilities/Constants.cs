namespace DataStore.Abstraction.Utilities
{
    public class Constants
    {
        public static class CommonErrorMessages
        {
            public const string NotFound = "{0} Not found with Id: {1}.";
        }

        public static class StoredProcedures
        {
            public const string GetCourseById = "sp_GetCourseByID";
            public const string GetAllCourses = "sp_GetAllCourses";
        }
    }
}

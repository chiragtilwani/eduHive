using DataStore.Abstraction.Repository;
using DataStore.Implementation.Repository;
using FeatureObjects.Abstraction.AbstractObject;
using FeatureObjects.Implementaion.FeatureObject;

namespace get.Knowledge.API
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICourseCategoryRepository, CourseCategoryRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            return services;
        }
        public static IServiceCollection AddManagers(this IServiceCollection services)
        {
            services.AddScoped<ICourseCategoryManager, CourseCategoryManager>();
            services.AddScoped<ICourseManager, CourseManager>();
            return services;
        }
    }
}

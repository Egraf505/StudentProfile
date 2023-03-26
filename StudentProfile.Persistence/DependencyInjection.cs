using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentProfile.Application.Interfaces;
using StudentProfile.Persistence.Context;

namespace StudentProfile.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<StudentProfileContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<IStudentProfileContext>(provider =>
                provider.GetService<StudentProfileContext>()!);
            return services;
        }
    }
}

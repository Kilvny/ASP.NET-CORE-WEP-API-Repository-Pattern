using NKRY_API.Domain.Contracts;
using NKRY_API.Repositories.UnitOfWorks;

namespace NKRY_API.Services
{
    public static class ServiceExtensions
    {
        public static void ConfigureUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}

using Contracts;
using Repository;

namespace BEC_Remalla.Extensions
{
    /// <summary>
    /// Service Extensions
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// Configures Repository Wrapper
        /// </summary>
        /// <param name="services">IServiceCollection object</param>
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}

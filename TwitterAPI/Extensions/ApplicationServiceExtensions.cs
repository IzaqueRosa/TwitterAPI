using Twitter.Domain.Interfaces.Services;
using Twitter.Domain.Services;

namespace TwitterAPI.Extensions
{
    /// <summary>
    /// API configuration class
    /// </summary>
    public static class ApplicationServiceExtensions
    {
        /// <summary>
        /// Method responsible for injecting service dependencies
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static IServiceCollection AddServiceInjection(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ITwitterService, TwitterService>();
            return services;
        }
    }
}

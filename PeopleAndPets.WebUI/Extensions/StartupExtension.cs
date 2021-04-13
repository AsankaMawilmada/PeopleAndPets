using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PeopleAndPets.Core.Configurations;
using PeopleAndPets.Core.Constants;
using PeopleAndPets.Core.Interfaces.Services;
using PeopleAndPets.Core.Services;

namespace PeopleAndPets.WebUI.Extensions
{
    public static class StartupExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IPeopleService, PeopleService>();
        }
        public static void AddConfigSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();

            var appSettingsSection = configuration.GetSection(AppSettingConstants.AppSettings);
            services.Configure<AppSettings>(appSettingsSection);
        }
    }
}

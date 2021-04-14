using Microsoft.Extensions.Options;
using PeopleAndPets.Core.Configurations;

namespace PeopleAndPets.Core.Tests.Helpers
{
    public static class OptionsBuilder
    {
        public static IOptions<AppSettings> AppSettingsConfig()
        {
            return Options.Create<AppSettings>(new AppSettings { PeopleAndPetsAPIBaseURL = "http://example/" });
        }
    }
}

using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PeopleAndPets.Core.Configurations;
using PeopleAndPets.Core.Interfaces.Services;
using PeopleAndPets.Core.Interfaces.Services.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace PeopleAndPets.Core.Services
{
    public class PeopleService : IPeopleService
    {
        private readonly AppSettings _appSettings;
        public PeopleService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public async Task<List<Person>> GetPeopleAsync()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{_appSettings.PeopleAndPetsAPIBaseURL}people.json");
                response.EnsureSuccessStatusCode();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<List<Person>>(content);

                    return result;
                }

                return new List<Person>();
            }
        }
    }
}

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
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly AppSettings _appSettings;
        public PeopleService(IHttpClientFactory httpClientFactory, IOptions<AppSettings> appSettings)
        {
            _httpClientFactory = httpClientFactory;
            _appSettings = appSettings.Value;
        }

        public async Task<List<Person>> GetPeopleAsync()
        {
            using (HttpClient httpclient = _httpClientFactory.CreateClient())
            using (HttpResponseMessage response = await httpclient.GetAsync($"{_appSettings.PeopleAndPetsAPIBaseURL}people.json"))
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<List<Person>>(content);

                    return result;
                }
                return null;
            }       
        }
    }
}

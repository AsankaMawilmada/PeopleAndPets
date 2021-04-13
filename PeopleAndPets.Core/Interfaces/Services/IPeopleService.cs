using PeopleAndPets.Core.Interfaces.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PeopleAndPets.Core.Interfaces.Services
{
    public interface IPeopleService
    {
        Task<List<Person>> GetPeopleAsync();
    }
}

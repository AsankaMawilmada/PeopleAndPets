using AutoMapper;
using PeopleAndPets.Core.Application.People.Dtos;
using PeopleAndPets.Core.Interfaces.Services.Models;

namespace PeopleAndPets.Core.Application.People
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<Person, PersonEnvelope>(MemberList.None);
            //CreateMap<Pet, PetEnvelope>(MemberList.None);
        }
    }
}

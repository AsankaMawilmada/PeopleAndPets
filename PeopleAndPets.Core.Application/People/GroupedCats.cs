using AutoMapper;
using MediatR;
using PeopleAndPets.Core.Application.People.Dtos;
using PeopleAndPets.Core.Interfaces.Services;
using PeopleAndPets.Core.Interfaces.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PeopleAndPets.Core.Application.People
{
    public class GroupedCats
    {
        public class Query : IRequest<List<GenderGroupEnvelope>>
        {

        }

        public class QueryHandler : IRequestHandler<Query, List<GenderGroupEnvelope>>
        {          
            private readonly IPeopleService _peopleService;
            public QueryHandler(IPeopleService peopleService)
            {
                _peopleService = peopleService;
            }
            public async Task<List<GenderGroupEnvelope>> Handle(Query request, CancellationToken cancellationToken)
            {
                const string filter = "Cat";
                var people = await _peopleService.GetPeopleAsync();

                return people
                    .Where(o => o.Pets != null && o.Pets.Any(d => d.Type.Equals(filter, StringComparison.CurrentCultureIgnoreCase)))
                    .Select(o => new Person
                    {
                        Name = o.Name,
                        Gender = o.Gender,
                        Age = o.Age,
                        Pets = o.Pets.Where(d => d.Type.Equals(filter, StringComparison.CurrentCultureIgnoreCase)).ToArray()
                    }).GroupBy(g => g.Gender)
                    .Select(grp => new GenderGroupEnvelope 
                    { 
                        Gender = grp.Key, 
                        Pets = grp.SelectMany( o => o.Pets.OrderBy(or => or.Name).Select(p => p.Name)).ToArray() 
                    })
                    .ToList();
            }
        }
    }
}

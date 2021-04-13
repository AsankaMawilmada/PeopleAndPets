using MediatR;
using Microsoft.AspNetCore.Mvc;
using PeopleAndPets.Core.Application.People;
using PeopleAndPets.Core.Application.People.Dtos;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PeopleAndPets.WebUI.Features.Controllers
{
    [Route("api/cats")]
    public class CatsController : BaseController
    {
        private readonly IMediator _mediator;

        public CatsController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("grouped")]
        public async Task<List<GenderGroupEnvelope>> Get(GroupedCats.Query query, CancellationToken cancellationToken)
        {
            return await _mediator.Send(query, cancellationToken);
        }
    }
}

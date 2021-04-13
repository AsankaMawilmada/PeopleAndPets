using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PeopleAndPets.WebUI.Features
{
    public class BaseController : Controller
    {
        private readonly IMediator _mediator;

        public BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}

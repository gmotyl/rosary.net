using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Rosary.Commands;
using Rosary.Queries;

namespace Rosary.Controllers
{
    [ApiController]
    public class IntentionController : ControllerBase
    {

        private readonly IMediator mediator;
        public IntentionController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("/intentions/{id}")]
        public async Task<IActionResult> GetIntentionById(Guid id)
        {
            var response = await mediator.Send(new GetIntentionById.Query(id));

            return response == null ? NotFound() : Ok(response);
        }

        [HttpPost("/intentions")]
        public async Task<ActionResult<AddIntention.Command>> AddIntention(AddIntention.Command command)
        {
            var response = await mediator.Send(command);
            return Ok(response); ;
        }

    }
}
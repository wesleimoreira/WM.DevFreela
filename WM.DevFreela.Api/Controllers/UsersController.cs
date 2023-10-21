using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WM.DevFreela.Application.Commands.CreateUser;
using WM.DevFreela.Application.Queries.GetUser;

namespace WM.DevFreela.Api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<CreateUserCommand> _validator;

        public UsersController(IMediator mediator, IValidator<CreateUserCommand> validator)
        {
            _mediator = mediator;
            _validator = validator;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _mediator.Send(new GetUserQuery(id));

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]      
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            var result = await _validator.ValidateAsync(command);

            if (!result.IsValid)
                return BadRequest(result.Errors.Select(x => x.ErrorMessage));

            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id }, command);
        }

    }
}

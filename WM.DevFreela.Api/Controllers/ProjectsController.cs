using MediatR;
using Microsoft.AspNetCore.Mvc;
using WM.DevFreela.Application.Commands.CreateComment;
using WM.DevFreela.Application.Commands.CreateProject;
using WM.DevFreela.Application.Commands.DeleteProject;
using WM.DevFreela.Application.Commands.FinishProject;
using WM.DevFreela.Application.Commands.UpdateProject;
using WM.DevFreela.Application.Queries.GetAllProjects;
using WM.DevFreela.Application.Queries.GetProjectById;

namespace WM.DevFreela.Api.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteProjectCommand(id));

            return NoContent();
        }

        [HttpPut("{id:int}/start")]
        public async Task<IActionResult> Start(int id)
        {
            await _mediator.Send(new FinishProjectCommand(id));

            return NoContent();
        }

        [HttpPut("{id:int}/finish")]
        public async Task<IActionResult> Finish(int id)
        {
            await _mediator.Send(new FinishProjectCommand(id));

            return NoContent();
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var project = await _mediator.Send(new GetProjectByIdQuery(id));

            if (project == null)
                return NotFound();

            return Ok(project);
        }

        [HttpGet]
        public async Task<IActionResult> Get(string query)
        {
            return Ok(await _mediator.Send(new GetAllProjectQuery(query)));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProjectCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id }, command);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateProjectCommand command)
        {
            var projectId = await _mediator.Send(command);

            if (projectId == 0) return NotFound();

            return NoContent();
        }

        [HttpPost("{id:int}/comment")]
        public async Task<IActionResult> PostComment(int id, [FromBody] CreateCommentCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
    }
}

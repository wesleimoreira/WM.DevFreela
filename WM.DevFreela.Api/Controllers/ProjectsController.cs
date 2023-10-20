using Microsoft.AspNetCore.Mvc;
using WM.DevFreela.Application.InputModels;
using WM.DevFreela.Application.Services.Interfaces;

namespace WM.DevFreela.Api.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectsController(IProjectService projectService)=> _projectService = projectService;

        [HttpGet]
        public IActionResult Get(string query)
        {
            return Ok(_projectService.GetAll(query));
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var project = _projectService.GetById(id);

            if(project == null)
                return NotFound();

            return Ok(project);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateProjectInputModel inputModel)
        {
            var id = _projectService.Create(inputModel);

            return CreatedAtAction(nameof(GetById), new { id }, inputModel);
        }

        [HttpPut]
        public IActionResult Put([FromBody] UpdateProjectInputModel inputModel)
        {
            _projectService.Update(inputModel);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            _projectService.Delect(id);

            return NoContent();
        }

        [HttpPost("{id:int}/comment")]
        public IActionResult PostComment(int id, [FromBody] CreateCommentInputmodel inputmodel)
        {
            _projectService.CreateComment(inputmodel);

            return NoContent();
        }

        [HttpPut("{id:int}/start")]
        public IActionResult Start(int id)
        {
            _projectService.Start(id);

            return NoContent();
        }

        [HttpPut("{id:int}/finish")]
        public IActionResult Finish(int id)
        {
            _projectService.Finsh(id);

            return NoContent(); 
        }
    }
}

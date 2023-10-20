using Microsoft.AspNetCore.Mvc;
using WM.DevFreela.Application.Services.Interfaces;

namespace WM.DevFreela.Api.Controllers
{
    [ApiController]
    [Route("api/skills")]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillService _skillService;
        public SkillsController(ISkillService skillService) => _skillService = skillService;

        [HttpGet]
        public IActionResult Get()
        {
            var skills = _skillService.GetAll();

            return Ok(skills);
        }
    }
}

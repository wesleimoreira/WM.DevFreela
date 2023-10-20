using Microsoft.AspNetCore.Mvc;
using WM.DevFreela.Application.InputModels;
using WM.DevFreela.Application.Services.Interfaces;

namespace WM.DevFreela.Api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService) => _userService = userService;
       
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetUser(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }
      
        [HttpPost]
        public IActionResult Post([FromBody] CreateUserInputModel inputModel)
        {
            var id = _userService.Create(inputModel);

            return CreatedAtAction(nameof(GetById), new { id }, inputModel);
        }      
        
    }
}

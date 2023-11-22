using Entities;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Services;
using System.Text.Json;

namespace MyFirstWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<User>> Get([FromQuery] string userName, [FromQuery] string password)
        {
            User user = await _userService.GetUserByEmailAndPassword(userName, password);
            if(user == null)
                return NoContent();
            return Ok(user);     
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            User user = await _userService.GetUserById(id);
            if (user == null)
                return NoContent();
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] User user)
        {
            try
            {
                User newUser = await _userService.AddUser(user);
                if(newUser == null)
                {
                    return BadRequest();
                }
                //return CreatedAtAction(nameof(Get), new { id = newUser.Id }, newUser); return newUser
                return CreatedAtAction(nameof(Get), new { id = newUser.Id }, user);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [Route("pwd")]
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] string password)
        {
            int res = await _userService.CheckPassword(password);
            if (res <= 2)
                return BadRequest(res);
            return Ok(res);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] User userToUpdate)
        {
            User user = await _userService.UpdateUser(id, userToUpdate);
            if(user == null) 
                return NoContent();
            return  Ok(user); 
        }
    }
}

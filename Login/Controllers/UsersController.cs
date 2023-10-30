using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Service;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        // GET: api/<UsersController>
        [HttpGet]
        public ActionResult<User> Get([FromQuery] string userName, [FromQuery] string password)
        {
            User user = _userService.GetUserByEmailAndPassword(userName, password);
            if(user == null)
                return NoContent();
            return Ok(user);     
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            User user = _userService.GetUserById(id);
            if(user == null) 
                return NoContent(); 
            return Ok(user);
        }

        // POST api/<UsersController>
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            try
            {
                User newUser = _userService.AddUser(user);
                return CreatedAtAction(nameof(Get), new { id = newUser.Id }, user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("pwd")]
        [HttpPost]
        public ActionResult<int> Post([FromBody] string password)
        {
            int res = _userService.CheckPassword(password);
            if (res <= 2)
                return BadRequest(res);
            return Ok(res);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] User updatedUser)
        {
            User user = _userService.UpdateUser(id, updatedUser);
            if(user == null) 
                return NoContent();
            return Ok(); 
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

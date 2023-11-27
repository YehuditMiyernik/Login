using AutoMapper;
using DTO;
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
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Get([FromBody] UserLoginDTO user)
        {
            User userlogin = await _userService.GetUserByEmailAndPassword(user.UserName, user.Password);
            UserDTO userDTO = _mapper.Map<User, UserDTO>(userlogin);
            if(user == null)
                return NoContent();
            return Ok(userDTO);     
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> Get(int id)
        {
            User user = await _userService.GetUserById(id);
            if (user == null)
                return NoContent();
            UserDTO userDTO = _mapper.Map<User, UserDTO>(user);
            return Ok(userDTO);
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> Post([FromBody] UserDTO userDTO)
        {
            User user = _mapper.Map<UserDTO, User>(userDTO);
            try
            {
                User newUser = await _userService.AddUser(user);
                if (newUser == null)
                {
                    return StatusCode(500);
                }
                UserDTO userToReturn = _mapper.Map<User, UserDTO>(user);
                return CreatedAtAction(nameof(Get), new { id = user.Id }, userToReturn);
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
        public async Task<ActionResult> Put(int id, [FromBody] UserDTO userDTOToUpdate)
        {
            User userToUpdate = _mapper.Map<UserDTO, User>(userDTOToUpdate);
            User user = await _userService.UpdateUser(id, userToUpdate);
            if(user == null) 
                return NoContent();
            UserDTO userDTO = _mapper.Map<User, UserDTO>(user);
            return  Ok(userDTO); 
        }
    }
}

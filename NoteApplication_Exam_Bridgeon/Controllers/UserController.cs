using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NoteApplication_Exam_Bridgeon.Data.AppliactionDbContext;
using NoteApplication_Exam_Bridgeon.Entities.Models.DTO;
using NoteApplication_Exam_Bridgeon.Entities.Models.UserModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NoteApplication_Exam_Bridgeon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository)
        {

            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }



        [HttpGet("get-all-users")]
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<IEnumerable<User>>> GetUserById()
        {
            try
            {
                var users = await _userRepository.GetAllUsers();

                return users != null ? Ok(users) : NotFound("No users found");

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
                throw;
            }
        }


        [HttpGet("{id} get-user-by-id")]
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<User>> GetUserById([FromRoute] int userId)
        {
            try
            {
                var user = await _userRepository.GetUserById(userId);

                return user != null ? Ok(user) : NotFound($"User with id not found! {userId}");

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
                throw;
            }
        }


        [HttpPost("create-user")]
        public async Task<ActionResult<User>> CreateNewUser([FromForm] UserInputDTO user)
        {
            try
            {
                if (user != null)
                {
                    User? usr = _mapper.Map<User>(user);
                    bool result = await _userRepository.CreateUser(usr);

                    return result ? CreatedAtRoute("get-user-by-id", new { }, result) : BadRequest();
                }
                else
                {
                    return BadRequest("USer Can't be null");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
                throw;
            }

        }






    }





}




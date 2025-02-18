using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementAppAPI.User.Data.Access;

namespace ProjectManagementAppAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(IUserRepository userRepository) : Controller
    {
        private readonly IUserRepository userRepository = userRepository;

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await userRepository.GetAllAsync());
        }

        [HttpGet("ByUserId/{userId}")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            return Ok(await userRepository.GetByIdAsync(userId));
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User.Data.Model.User user)
        {
            var userToCreate = await userRepository.CreateAsync(user);

            if (userToCreate == null)
                return StatusCode(500, ModelState);

            return Ok("Succesfully created!");
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser([FromBody] User.Data.Model.User user, int userId)
        {
            if (user.UserId != userId)
            {
                return StatusCode(500, ModelState);
            }

            return Ok(await userRepository.UpdateAsync(user));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int id)
        {
            return Ok(await userRepository.DeleteAsync(id));
        }
    }
}

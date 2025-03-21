using Microsoft.AspNetCore.Mvc;
using ProjectManagementAppAPI.Comment.Data.Access;
using ProjectManagementAppAPI.Task.Data.Access;

namespace ProjectManagementAppAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController(ICommentRepository commentRepository) : Controller
    {
        private readonly ICommentRepository commentRepository = commentRepository;

        [HttpGet]
        public async Task<IActionResult> GetAllComments()
        {
            return Ok(await commentRepository.GetAllAsync());
        }

        [HttpGet("ByCommentId/{id}")]
        public async Task<IActionResult> GetCommnetById(int id)
        {
            return Ok(await commentRepository.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody] Comment.Data.Model.Comment comment)
        {
            var commentToCreate = await commentRepository.CreateAsync(comment);

            if (commentToCreate == null)
                return StatusCode(500, ModelState);

            return Ok("Succesfully created!");
        }

        [HttpPut("{commentId}")]
        public async Task<IActionResult> UpdateComment([FromBody] Comment.Data.Model.Comment comment, int commentId)
        {
            if (comment.CommentId != commentId)
            {
                return StatusCode(500, ModelState);
            }

            return Ok(await commentRepository.UpdateAsync(comment));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteComment(int id)
        {
            return Ok(await commentRepository.DeleteAsync(id));
        }

        [HttpGet("CommentByTaskId/{taskId}")]
        public async Task<IActionResult> GetByTaskId(int taskId)
        {
            return Ok(await commentRepository.GetByTaskIdAsync(taskId));
        }

        [HttpGet("CommentByUserId/{userId}")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            return Ok(await commentRepository.GetByUserIdAsync(userId));
        }
    }
}

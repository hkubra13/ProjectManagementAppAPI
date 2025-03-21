using Microsoft.AspNetCore.Mvc;
using ProjectManagementAppAPI.List.Data.Access;
using ProjectManagementAppAPI.Task.Data.Access;

namespace ProjectManagementAppAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController(ITaskRepository taskRepository) : Controller
    {
        private readonly ITaskRepository taskRepository = taskRepository;

        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            return Ok(await taskRepository.GetAllAsync());
        }

        [HttpGet("ByTaskId/{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            return Ok(await taskRepository.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] Task.Data.Model.Task task)
        {
            var taskToCreate = await taskRepository.CreateAsync(task);

            if (taskToCreate == null)
                return StatusCode(500, ModelState);

            return Ok("Succesfully created!");
        }

        [HttpPut("{taskId}")]
        public async Task<IActionResult> UpdateTask([FromBody] Task.Data.Model.Task task, int taskId)
        {
            if (task.TaskId != taskId)
            {
                return StatusCode(500, ModelState);
            }

            return Ok(await taskRepository.UpdateAsync(task));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTask(int id)
        {
            return Ok(await taskRepository.DeleteAsync(id));
        }

        [HttpGet("TaskByListId/{listId}")]
        public async Task<IActionResult> GetByListId(int listId)
        {
            return Ok(await taskRepository.GetByListIdAsync(listId));
        }

        [HttpGet("TaskByUserId/{userId}")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            return Ok(await taskRepository.GetByUserIdAsync(userId));
        }
    }
}

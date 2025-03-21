using Microsoft.AspNetCore.Mvc;
using ProjectManagementAppAPI.ActivityLog.Data.Access;
using ProjectManagementAppAPI.Comment.Data.Access;

namespace ProjectManagementAppAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActivityLogController(IActivityLogRepository activityLogRepository) : Controller
    {
        private readonly IActivityLogRepository activityLogRepository = activityLogRepository;

        [HttpGet]
        public async Task<IActionResult> GetAllActivityLogs()
        {
            return Ok(await activityLogRepository.GetAllAsync());
        }

        [HttpGet("ByActivityLogId/{id}")]
        public async Task<IActionResult> GetActivityLogById(int id)
        {
            return Ok(await activityLogRepository.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateActivityLog([FromBody] ActivityLog.Data.Model.ActivityLog activityLog)
        {
            var activityLogToCreate = await activityLogRepository.CreateAsync(activityLog);

            if (activityLogToCreate == null)
                return StatusCode(500, ModelState);

            return Ok("Succesfully created!");
        }

        [HttpPut("{activityLogId}")]
        public async Task<IActionResult> UpdateActivityLog([FromBody] ActivityLog.Data.Model.ActivityLog activityLog, int activityLogId)
        {
            if (activityLog.ActivityLogId != activityLogId)
            {
                return StatusCode(500, ModelState);
            }

            return Ok(await activityLogRepository.UpdateAsync(activityLog));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteActivityLog(int id)
        {
            return Ok(await activityLogRepository.DeleteAsync(id));
        }

        [HttpGet("ActivityLogByTaskId/{taskId}")]
        public async Task<IActionResult> GetByTaskId(int taskId)
        {
            return Ok(await activityLogRepository.GetByTaskIdAsync(taskId));
        }

        [HttpGet("ActivityLogByUserId/{userId}")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            return Ok(await activityLogRepository.GetByUserIdAsync(userId));
        }
    }
}

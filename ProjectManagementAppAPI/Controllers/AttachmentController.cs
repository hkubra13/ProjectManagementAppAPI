using Microsoft.AspNetCore.Mvc;
using ProjectManagementAppAPI.ActivityLog.Data.Access;
using ProjectManagementAppAPI.Attachment.Data.Access;

namespace ProjectManagementAppAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttachmentController(IAttachmentRepository attachmentRepository) : Controller
    {
        private readonly IAttachmentRepository attachmentRepository = attachmentRepository;

        [HttpGet]
        public async Task<IActionResult> GetAllAttachmnets()
        {
            return Ok(await attachmentRepository.GetAllAsync());
        }

        [HttpGet("ByAttachmentId/{id}")]
        public async Task<IActionResult> GetAttachmentById(int id)
        {
            return Ok(await attachmentRepository.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAttachment([FromBody] Attachment.Data.Model.Attachment attachment)
        {
            var attachmentToCreate = await attachmentRepository.CreateAsync(attachment);

            if (attachmentToCreate == null)
                return StatusCode(500, ModelState);

            return Ok("Succesfully created!");
        }

        [HttpPut("{attachmentId}")]
        public async Task<IActionResult> UpdateAttachment([FromBody] Attachment.Data.Model.Attachment attachment, int attachmentId)
        {
            if (attachment.AttachmentId != attachmentId)
            {
                return StatusCode(500, ModelState);
            }

            return Ok(await attachmentRepository.UpdateAsync(attachment));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAttachment(int id)
        {
            return Ok(await attachmentRepository.DeleteAsync(id));
        }

        [HttpGet("AttachmentByTaskId/{taskId}")]
        public async Task<IActionResult> GetByTaskId(int taskId)
        {
            return Ok(await attachmentRepository.GetByTaskIdAsync(taskId));
        }
    }
}

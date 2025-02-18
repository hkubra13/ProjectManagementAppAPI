using Microsoft.AspNetCore.Mvc;
using ProjectManagementAppAPI.Project.Data.Access;
using ProjectManagementAppAPI.User.Data.Access;

namespace ProjectManagementAppAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController(IProjectRepository projectRepository) : Controller
    {
        private readonly IProjectRepository projectRepository = projectRepository;

        [HttpGet]
        public async Task<IActionResult> GetAllProjects()
        {
            return Ok(await projectRepository.GetAllAsync());
        }

        [HttpGet("ByProjectId/{id}")]
        public async Task<IActionResult> GetProjectById(int id)
        {
            return Ok(await projectRepository.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject([FromBody] Project.Data.Model.Project project)
        {
            var projectToCreate = await projectRepository.CreateAsync(project);

            if (projectToCreate == null)
                return StatusCode(500, ModelState);

            return Ok("Succesfully created!");
        }

        [HttpPut("{projectId}")]
        public async Task<IActionResult> UpdateProject([FromBody] Project.Data.Model.Project project, int projectId)
        {
            if (project.ProjectId != projectId)
            {
                return StatusCode(500, ModelState);
            }

            return Ok(await projectRepository.UpdateAsync(project));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProject(int id)
        {
            return Ok(await projectRepository.DeleteAsync(id));
        }

        [HttpGet("ProjectByUserId/{userId}")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            return Ok(await projectRepository.GetByUserIdAsync(userId));
        }
    }
}

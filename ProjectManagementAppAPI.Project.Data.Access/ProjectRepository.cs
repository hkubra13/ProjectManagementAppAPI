using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementAppAPI.Project.Data.Access
{
    public class ProjectRepository(ProjectDbContext context) : IProjectRepository
    {
        private readonly ProjectDbContext context = context;

        public async Task<Model.Project> CreateAsync(Model.Project project)
        {
            context.Add(project);
            await context.SaveChangesAsync();
            return project;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var project = await GetByIdAsync(id) ?? throw new Exception("Project not found");
            context.Remove(project);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Model.Project>> GetAllAsync()
        {
            return await context.Projects.ToListAsync();
        }

        public async Task<Model.Project> GetByIdAsync(int id)
        {
            var project = await context.Projects.Where(p => p.ProjectId == id).FirstOrDefaultAsync();
            return project ?? throw new Exception("Project not found");
        }

        public async Task<IEnumerable<Model.Project>> GetByUserIdAsync(int id)
        {
            var project = await context.Projects.Where(p => p.UserId == id).ToListAsync();
            return project ?? throw new Exception("Project not found");
        }

        public async Task<Model.Project> UpdateAsync(Model.Project project)
        {
            context.Entry(project).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return project;
        }
    }
}

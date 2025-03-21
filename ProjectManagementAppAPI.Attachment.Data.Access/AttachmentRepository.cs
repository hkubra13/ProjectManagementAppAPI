using Microsoft.EntityFrameworkCore;
using ProjectManagementAppAPI.Task.Data.Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementAppAPI.Attachment.Data.Access
{
    public class AttachmentRepository(AttachmentDbContext attachmentDbContext, TaskDbContext taskDbContext) : IAttachmentRepository
    {
        private readonly AttachmentDbContext context = attachmentDbContext;
        private readonly TaskDbContext taskDbContext = taskDbContext;

        public async Task<Model.Attachment> CreateAsync(Model.Attachment attachment)
        {
            context.Add(attachment);
            await context.SaveChangesAsync();
            return attachment;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var attachment = await GetByIdAsync(id) ?? throw new Exception("Attachment not found");
            context.Remove(attachment);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Model.Attachment>> GetAllAsync()
        {
            return await context.Attachments.ToListAsync();
        }

        public async Task<Model.Attachment> GetByIdAsync(int id)
        {
            var attachment = await context.Attachments.Where(a => a.AttachmentId == id).FirstOrDefaultAsync();
            return attachment ?? throw new Exception("Attachment not found");
        }

        public async Task<IEnumerable<Model.Attachment>> GetByTaskIdAsync(int id)
        {
            var taskExists = await taskDbContext.Tasks.AnyAsync(t => t.TaskId == id);

            if (!taskExists)
                throw new Exception("Task not found");

            var attachments = await context.Attachments.ToListAsync();
            return attachments.Where(a => a.TaskId == id);
        }

        public async Task<Model.Attachment> UpdateAsync(Model.Attachment attachment)
        {
            context.Entry(attachment).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return attachment;
        }
    }
}

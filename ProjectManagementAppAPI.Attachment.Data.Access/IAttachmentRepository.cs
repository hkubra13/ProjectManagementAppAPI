using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementAppAPI.Attachment.Data.Access
{
    public interface IAttachmentRepository
    {
        public Task<IEnumerable<Model.Attachment>> GetAllAsync();
        public Task<Model.Attachment> GetByIdAsync(int id);
        public Task<IEnumerable<Model.Attachment>> GetByTaskIdAsync(int id);
        public Task<Model.Attachment> CreateAsync(Model.Attachment attachment);
        public Task<Model.Attachment> UpdateAsync(Model.Attachment attachment);
        public Task<bool> DeleteAsync(int id);
    }
}

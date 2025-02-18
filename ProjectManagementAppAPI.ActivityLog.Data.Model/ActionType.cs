using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementAppAPI.ActivityLog.Data.Model
{
    public enum ActionType
    {
        TaskCreated = 0,
        TaskUpdated = 1,
        TaskDeleted = 2,
        TaskStatusChanged = 3,
        CommentAdded = 4,
        AttachmentAdded = 5
    }
}

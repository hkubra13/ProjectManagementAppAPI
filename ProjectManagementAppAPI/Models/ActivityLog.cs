using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagementAppAPI.Models
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
    public class ActivityLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Task")]
        public int TaskId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public ActionType Action { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}

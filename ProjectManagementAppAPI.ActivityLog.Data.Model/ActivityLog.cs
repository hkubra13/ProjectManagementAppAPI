using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagementAppAPI.ActivityLog.Data.Model
{

    public class ActivityLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ActivityLogId { get; set; }

        [ForeignKey("Task")]
        public int TaskId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public ActionType Action { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}

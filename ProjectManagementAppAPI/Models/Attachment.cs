using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagementAppAPI.Models
{
    public class Attachment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Task")]
        public int TaskId { get; set; }

        public string FileName { get; set; }
        public string FilePath { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}

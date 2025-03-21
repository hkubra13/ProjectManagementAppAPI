﻿using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagementAppAPI.Task.Data.Model
{
    public class Task
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        [ForeignKey("List")]
        public int ListId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public DateTime? DueDate { get; set; }
        public TaskStatus Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}

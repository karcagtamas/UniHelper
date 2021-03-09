using System;
using UniHelper.Shared.Enums;

namespace UniHelper.Shared.DTOs
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime DueDate { get; set; }
        public TaskPriority Priority { get; set; }
        public bool IsSolved { get; set; }
        public TaskType Type { get; set; }
    }
}
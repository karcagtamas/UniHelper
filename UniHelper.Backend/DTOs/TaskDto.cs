using System;
using UniHelper.Backend.Enums;

namespace UniHelper.Backend.DTOs
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime DueDate { get; set; }
        public TaskPriority Priority { get; set; }
        public bool IsSolved { get; set; }
    }
}
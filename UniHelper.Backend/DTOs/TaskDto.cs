using System;

namespace UniHelper.Backend.DTOs
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime DueDate { get; set; }
        public int Priority { get; set; }
        public bool IsSolved { get; set; }
    }
}
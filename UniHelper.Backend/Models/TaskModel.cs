using System;

namespace UniHelper.Backend.Models
{
    public class TaskModel
    {
        public string Text { get; set; }
        public DateTime DueDate { get; set; }
        public int Priority { get; set; }
        public bool IsSolved { get; set; }
    }
}
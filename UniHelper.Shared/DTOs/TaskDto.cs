using System;
using UniHelper.Shared.Enums;

namespace UniHelper.Shared.DTOs
{
    /// <summary>
    /// Task DTO
    /// </summary>
    public class TaskDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Task
        /// </summary>
        public string Text { get; set; }
        
        /// <summary>
        /// Due Date
        /// </summary>
        public DateTime DueDate { get; set; }
        
        /// <summary>
        /// Priority
        /// </summary>
        public TaskPriority Priority { get; set; }
        
        /// <summary>
        /// Is Solved status
        /// </summary>
        public bool IsSolved { get; set; }
        
        /// <summary>
        /// Type
        /// </summary>
        public TaskType Type { get; set; }
    }
}
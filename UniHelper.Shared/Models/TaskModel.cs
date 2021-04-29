using System;
using System.ComponentModel.DataAnnotations;
using UniHelper.Shared.DTOs;
using UniHelper.Shared.Enums;

namespace UniHelper.Shared.Models
{
    /// <summary>
    /// Task Model
    /// </summary>
    public class TaskModel
    {
        /// <summary>
        /// Task
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string Text { get; set; } = "";

        /// <summary>
        /// Due Date
        /// </summary>
        [Required]
        public DateTime? DueDate { get; set; }

        /// <summary>
        /// Priority
        /// </summary>
        [Required]
        public TaskPriority Priority { get; set; }

        /// <summary>
        /// Is Solved
        /// </summary>
        [Required]
        public bool IsSolved { get; set; }

        /// <summary>
        /// Task Model Init
        /// </summary>
        public TaskModel() { }

        /// <summary>
        /// Task Model Init
        /// </summary>
        /// <param name="task">Task DTO</param>
        public TaskModel(TaskDto task)
        {
            Text = task.Text;
            DueDate = task.DueDate;
            Priority = task.Priority;
            IsSolved = task.IsSolved;
        }
    }
}
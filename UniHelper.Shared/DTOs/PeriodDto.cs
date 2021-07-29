using System;
using System.Collections.Generic;

namespace UniHelper.Shared.DTOs
{
    /// <summary>
    /// Period DTO
    /// </summary>
    public class PeriodDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Period Title
        /// </summary>
        public string Name { get; set; } = "";
        
        /// <summary>
        /// Is Current
        /// </summary>
        public bool IsCurrent { get; set; }
        
        /// <summary>
        /// Period Start
        /// </summary>
        public DateTime Start { get; set; }
        
        /// <summary>
        /// Period End
        /// </summary>
        public DateTime End { get; set; }
        
        /// <summary>
        /// Subjects
        /// </summary>
        public List<SubjectDto> Subjects { get; set; } = new List<SubjectDto>();
        
        /// <summary>
        /// Tasks
        /// </summary>
        public List<TaskDto> Tasks { get; set; } = new List<TaskDto>();
        
        /// <summary>
        /// Owner
        /// </summary>
        public int UserId { get; set; }
    }
}
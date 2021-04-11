using System.Collections.Generic;
using UniHelper.Shared.Enums;

namespace UniHelper.Shared.DTOs
{
    /// <summary>
    /// Subject DTO
    /// </summary>
    public class SubjectDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Long Name
        /// </summary>
        public string LongName { get; set; }
        
        /// <summary>
        /// Short Name
        /// </summary>
        public string ShortName { get; set; }
        
        /// <summary>
        /// Code
        /// </summary>
        public string Code { get; set; }
        
        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// Credit count
        /// </summary>
        public int Credit { get; set; }
        
        /// <summary>
        /// Mark of subject
        /// </summary>
        public int? Result { get; set; }
        
        /// <summary>
        /// Active Status
        /// </summary>
        public bool IsActive { get; set; }
        
        /// <summary>
        /// Parent Period Id
        /// </summary>
        public int PeriodId { get; set; }
        
        /// <summary>
        /// Type
        /// </summary>
        public SubjectType Type { get; set; }
        
        /// <summary>
        /// Notes
        /// </summary>
        public List<NoteDto> Notes { get; set; }
        
        /// <summary>
        /// Tasks
        /// </summary>
        public List<TaskDto> Tasks { get; set; }
        
        /// <summary>
        /// Courses
        /// </summary>
        public List<CourseDto> Courses { get; set; }
    }
}
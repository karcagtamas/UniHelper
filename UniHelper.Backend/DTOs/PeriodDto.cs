using System;
using System.Collections.Generic;

namespace UniHelper.Backend.DTOs
{
    public class PeriodDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsCurrent { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; } 
        public virtual List<SubjectDto> Subjects { get; set; }
        public virtual List<NoteDto> Notes { get; set; }
        public virtual List<TaskDto> Tasks { get; set; }
    }
}
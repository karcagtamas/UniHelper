using System;
using System.Collections.Generic;

namespace UniHelper.Shared.DTOs
{
    public class PeriodDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsCurrent { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public List<SubjectDto> Subjects { get; set; }
        public List<NoteDto> Notes { get; set; }
        public List<TaskDto> Tasks { get; set; }
        public int UserId { get; set; }
    }
}
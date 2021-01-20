using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UniHelper.Backend.Entities;
using UniHelper.Backend.Enums;

namespace UniHelper.Backend.DTOs
{
    public class SubjectDto
    {
        public int Id { get; set; }
        public string LongName { get; set; }
        public string ShortName { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int Credit { get; set; }
        public int? Result { get; set; }
        public bool IsActive { get; set; }
        public int PeriodId { get; set; }
        public SubjectType Type { get; set; }
        public List<NoteDto> Notes { get; set; }
        public List<TaskDto> Tasks { get; set; }
        public List<CourseDto> Courses { get; set; }
    }
}
using System;
using System.Collections.Generic;
using Karcags.Common.Tools;

namespace UniHelper.Backend.Entities
{
    public class Period : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsCurrent { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual ICollection<PeriodNote> Notes { get; set; }
        public virtual ICollection<PeriodTask> Tasks { get; set; }
    }
}
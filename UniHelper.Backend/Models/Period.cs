using System;
using System.Collections.Generic;

namespace UniHelper.Backend.Models
{
    public class Period : IEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual ICollection<PeriodNote> Notes { get; set; }
        public virtual ICollection<PeriodTask> Tasks { get; set; }

        public Period()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
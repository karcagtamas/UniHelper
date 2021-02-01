
using System;
using System.ComponentModel.DataAnnotations;
using Karcags.Common.Tools;

namespace UniHelper.Backend.Entities
{
    public class LessonHour : IEntity
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public int Number { get; set; }

        [Required]
        public TimeSpan Start { get; set; }
        
        [Required]
        public TimeSpan End { get; set; }
    }
}
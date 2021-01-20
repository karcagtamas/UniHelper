using System.ComponentModel.DataAnnotations;
using Karcags.Common.Annotations;
using UniHelper.Backend.Enums;

namespace UniHelper.Backend.Models
{
    public class SubjectModel
    {
        [Required]
        [StringLength(100)]
        public string LongName { get; set; }
        
        [Required]
        [StringLength(20)]
        public string ShortName { get; set; }
        
        [Required]
        [StringLength(10)]
        public string Code { get; set; }
        public string Description { get; set; }
        
        [Required]
        [MinNumber(1)]
        public int Credit { get; set; }
        
        [MinNumber(1)]
        [MaxNumber(5)]
        public int? Result { get; set; }
        
        [Required]
        public bool IsActive { get; set; }
        
        [Required]
        public int PeriodId { get; set; }
        
        [Required]
        public SubjectType Type { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using UniHelper.Shared.Enums;

namespace UniHelper.Shared.Models
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
        public int Credit { get; set; }
        
        public int? Result { get; set; }
        
        [Required]
        public bool IsActive { get; set; }
        
        [Required]
        public int PeriodId { get; set; }
        
        [Required]
        public SubjectType Type { get; set; }
    }
}
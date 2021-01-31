using System.ComponentModel.DataAnnotations;
using UniHelper.Shared.DTOs;
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
        [StringLength(16)]
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

        public SubjectModel()
        {
            IsActive = true;
        }

        public SubjectModel(int periodId)
        {
            PeriodId = periodId;
            IsActive = true;
        }

        public SubjectModel(SubjectDto dto)
        {
            LongName = dto.LongName;
            ShortName = dto.ShortName;
            Code = dto.Code;
            Description = dto.Description;
            Credit = dto.Credit;
            Result = dto.Result;
            IsActive = dto.IsActive;
            PeriodId = dto.PeriodId;
            Type = dto.Type;
        }
    }
}
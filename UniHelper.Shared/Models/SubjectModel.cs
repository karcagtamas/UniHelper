using System.ComponentModel.DataAnnotations;
using UniHelper.Shared.DTOs;
using UniHelper.Shared.Enums;

namespace UniHelper.Shared.Models
{
    /// <summary>
    /// Subject Model
    /// </summary>
    public class SubjectModel
    {
        /// <summary>
        /// Long Name
        /// </summary>
        [Required]
        [StringLength(100)]
        public string LongName { get; set; }
        
        /// <summary>
        /// Short Name
        /// </summary>
        [Required]
        [StringLength(20)]
        public string ShortName { get; set; }
        
        /// <summary>
        /// Code
        /// </summary>
        [Required]
        [StringLength(16)]
        public string Code { get; set; }
        
        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// Credit number
        /// </summary>
        [Required]
        public int Credit { get; set; }
        
        /// <summary>
        /// Mark result
        /// </summary>
        public int? Result { get; set; }
        
        /// <summary>
        /// Is Active
        /// </summary>
        [Required]
        public bool IsActive { get; set; }
        
        /// <summary>
        /// Period Id
        /// </summary>
        [Required]
        public int PeriodId { get; set; }
        
        /// <summary>
        /// Type
        /// </summary>
        [Required]
        public SubjectType Type { get; set; }

        /// <summary>
        /// Subject Model Init
        /// </summary>
        public SubjectModel()
        {
            IsActive = true;
        }

        /// <summary>
        /// Subject Model Init
        /// </summary>
        /// <param name="periodId">Period Id</param>
        public SubjectModel(int periodId)
        {
            PeriodId = periodId;
            IsActive = true;
        }

        /// <summary>
        /// Subject Model Init
        /// </summary>
        /// <param name="dto">Subject DTO</param>
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
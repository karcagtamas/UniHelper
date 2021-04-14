using System;
using System.ComponentModel.DataAnnotations;
using UniHelper.Shared.DTOs;

namespace UniHelper.Shared.Models
{
    /// <summary>
    /// Period Model
    /// </summary>
    public class PeriodModel
    {
        /// <summary>
        /// Period Title
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        
        /// <summary>
        /// Is Current period
        /// </summary>
        [Required]
        public bool IsCurrent { get; set; }
        
        /// <summary>
        /// Period Start
        /// </summary>
        [Required]
        public DateTime? Start { get; set; }
        
        /// <summary>
        /// Period End
        /// </summary>
        [Required]
        public DateTime? End { get; set; }
        
        /// <summary>
        /// Owner
        /// </summary>
        [Required]
        public int UserId { get; set; }
        
        /// <summary>
        /// Period Model Init
        /// </summary>
        public PeriodModel() {}

        /// <summary>
        /// Period Model Init
        /// </summary>
        public PeriodModel(int userId)
        {
            UserId = userId;
        }

        /// <summary>
        /// Period Model Init
        /// </summary>
        /// <param name="dto">Period DTO</param>
        public PeriodModel(PeriodDto dto)
        {
            Name = dto.Name;
            IsCurrent = dto.IsCurrent;
            Start = dto.Start;
            End = dto.End;
            UserId = dto.UserId;
        }
    }
}
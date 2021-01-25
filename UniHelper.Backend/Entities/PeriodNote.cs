using System.ComponentModel.DataAnnotations;

namespace UniHelper.Backend.Entities
{
    /// <summary>
    /// Period Note
    /// </summary>
    public class PeriodNote : Note
    {
        /// <value>
        /// Period Id
        /// </value>
        [Required]
        public int PeriodId { get; set; }
        
        /// <value>
        /// Period
        /// </value>
        public virtual Period Period { get; set; }
    }
}
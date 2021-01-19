using System;

namespace UniHelper.Backend.Models
{
    public class Task : IEntity
    {
        /// <value>
        /// Task Id
        /// </value>
        public string Id { get; set; }
        
        /// <value>
        /// Task text
        /// </value>
        public string Text { get; set; }
        
        /// <value>
        /// Task due date
        /// </value>
        public DateTime DueDate { get; set; }
        
        /// <value>
        /// Task priority
        /// </value>
        public int Priority { get; set; }
        
        /// <summary>
        /// Task is solved
        /// </summary>
        public bool IsSolved { get; set; }
    }
}
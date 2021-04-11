using System;

namespace UniHelper.Shared.DTOs
{
    /// <summary>
    /// Note DTO
    /// </summary>
    public class NoteDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Note text
        /// </summary>
        public string Text { get; set; }
        
        /// <summary>
        /// Creation
        /// </summary>
        public DateTime Created { get; set; }
        
        /// <summary>
        /// Last Update
        /// </summary>
        public DateTime LastUpdated { get; set; }
        
        /// <summary>
        /// Is Closed
        /// </summary>
        public bool IsClosed { get; set; }
    }
}
using System;

namespace UniHelper.Shared.DTOs
{
    public class NoteDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool IsClosed { get; set; }
    }
}
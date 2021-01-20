using System;

namespace UniHelper.Backend.Models
{
    public class NoteModel
    {
        public string Text { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool IsClosed { get; set; }
    }
}
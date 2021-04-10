namespace UniHelper.Shared.Models
{
    /// <summary>
    /// Global Note Model
    /// </summary>
    public class GlobalNoteModel : NoteModel
    {
        /// <summary>
        /// Owner
        /// </summary>
        public int UserId { get; set; }
    }
}
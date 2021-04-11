namespace UniHelper.Shared.Models
{
    /// <summary>
    /// Subject Task Model
    /// </summary>
    public class SubjectTaskModel : TaskModel
    {
        /// <summary>
        /// Subject Id
        /// </summary>
        public int SubjectId { get; set; }
        
        /// <summary>
        /// Subject Task Model Init
        /// </summary>
        public SubjectTaskModel() {}

        /// <summary>
        /// Subject Task Model Init
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="model">Task model</param>
        public SubjectTaskModel(int id, TaskModel model)
        {
            SubjectId = id;
            Text = model.Text;
            DueDate = model.DueDate;
            Priority = model.Priority;
            IsSolved = model.IsSolved;
        }
    }
}
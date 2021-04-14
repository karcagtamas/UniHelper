namespace UniHelper.Shared.Models
{
    /// <summary>
    /// Global Task Model
    /// </summary>
    public class GlobalTaskModel : TaskModel
    {
        /// <summary>
        /// Owner
        /// </summary>
        public int UserId { get; set; }
        
        /// <summary>
        /// Global Task Model Init
        /// </summary>
        public GlobalTaskModel() { }

        /// <summary>
        /// Global Task Model Init
        /// </summary>
        /// <param name="model">Task Model</param>
        /// <param name="userId">Owner</param>
        public GlobalTaskModel(TaskModel model, int userId)
        {
            Text = model.Text;
            DueDate = model.DueDate;
            Priority = model.Priority;
            IsSolved = model.IsSolved;
            UserId = userId;
        }
    }
}
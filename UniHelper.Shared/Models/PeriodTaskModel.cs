namespace UniHelper.Shared.Models
{
    /// <summary>
    /// Period Task Model
    /// </summary>
    public class PeriodTaskModel : TaskModel
    {
        /// <summary>
        /// Period Id
        /// </summary>
        public int PeriodId { get; set; }
        
        /// <summary>
        /// Period Task Model Init
        /// </summary>
        public PeriodTaskModel() {}

        /// <summary>
        /// Period Task Model Init
        /// </summary>
        /// <param name="id">Period Id</param>
        /// <param name="model">Task model</param>
        public PeriodTaskModel(int id, TaskModel model)
        {
            PeriodId = id;
            Text = model.Text;
            DueDate = model.DueDate;
            Priority = model.Priority;
            IsSolved = model.IsSolved;
        }
    }
}
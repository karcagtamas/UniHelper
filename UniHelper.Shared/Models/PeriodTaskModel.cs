namespace UniHelper.Shared.Models
{
    public class PeriodTaskModel : TaskModel
    {
        public int PeriodId { get; set; }
        
        public PeriodTaskModel() {}

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
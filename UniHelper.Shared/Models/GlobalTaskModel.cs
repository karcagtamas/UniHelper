namespace UniHelper.Shared.Models
{
    public class GlobalTaskModel : TaskModel
    {
        public int UserId { get; set; }
        public GlobalTaskModel() { }

        public GlobalTaskModel(TaskModel model)
        {
            Text = model.Text;
            DueDate = model.DueDate;
            Priority = model.Priority;
            IsSolved = model.IsSolved;
        }
    }
}
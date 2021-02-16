namespace UniHelper.Shared.Models
{
    public class GlobalTaskModel : TaskModel
    {
        public GlobalTaskModel() {}

        public GlobalTaskModel(TaskModel model)
        {
            Text = model.Text;
            DueDate = model.DueDate;
            Priority = model.Priority;
            IsSolved = model.IsSolved;
        }
    }
}
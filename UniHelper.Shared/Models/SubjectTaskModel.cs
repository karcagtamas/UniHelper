namespace UniHelper.Shared.Models
{
    public class SubjectTaskModel : TaskModel
    {
        public int SubjectId { get; set; }
        
        public SubjectTaskModel() {}

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
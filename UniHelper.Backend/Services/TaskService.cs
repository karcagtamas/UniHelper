using System.Collections.Generic;
using UniHelper.Shared.Enums;

namespace UniHelper.Backend.Services
{
    /// <summary>
    /// Task Service
    /// </summary>
    public class TaskService : ITaskService
    {
        private readonly DatabaseContext _context;

        /// <summary>
        /// Init Task Service
        /// </summary>
        /// <param name="context">Database context</param>
        public TaskService(DatabaseContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public List<int> GetParentIdList(int id, TaskType type)
        {
            switch (type)
            {
                case TaskType.Period:
                {
                    var task = _context.PeriodTasks.Find(id);

                    return new List<int> {task.PeriodId};
                }
                case TaskType.Subject:
                {
                    var task = _context.SubjectTasks.Find(id);
                    return new List<int> {task.Subject.PeriodId, task.SubjectId};
                }
                default:
                    return new List<int>();
            }
        }
    }
}
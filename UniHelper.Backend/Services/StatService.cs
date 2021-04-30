using UniHelper.Shared.DTOs;

namespace UniHelper.Backend.Services
{
    /// <inheritdoc />
    public class StatService : IStatService
    {
        private readonly IPeriodService _periodService;

        private readonly ITaskService _taskService;

        /// <summary>
        /// Init Stat Service
        /// </summary>
        public StatService(IPeriodService periodService, ITaskService taskService) 
        {
            _periodService = periodService;
            _taskService = taskService;
        }

        /// <inheritdoc />
        public StatisticDto GetHomeStat()
        {
            return new StatisticDto();
        }
    }
}
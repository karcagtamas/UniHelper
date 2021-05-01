using UniHelper.Shared.DTOs;

namespace UniHelper.Backend.Services
{
    /// <inheritdoc />
    public class StatService : IStatService
    {
        private readonly IPeriodService _periodService;

        private readonly IGlobalTaskService _globalTaskService;
        private readonly ISubjectTaskService _subjectTaskService;
        private readonly IPeriodTaskService _periodTaskService;

        /// <summary>
        /// Init Stat Service
        /// </summary>
        public StatService(IPeriodService periodService, IGlobalTaskService globalTaskService, ISubjectTaskService subjectTaskService, IPeriodTaskService periodTaskService) 
        {
            _periodService = periodService;
            _globalTaskService = globalTaskService;
            _subjectTaskService = subjectTaskService;
            _periodTaskService = periodTaskService;
        }

        /// <inheritdoc />
        public StatisticDto GetHomeStat()
        {
            var stat = new StatisticDto {SolvedTasks = GetSolvedTaskNumber(), UnSolvedTasks = GetNotSolvedTaskNumber()};


            return stat;
        }

        private int GetSolvedTaskNumber()
        {
            var sum = 0;

            sum += _globalTaskService.GetList(x => x.IsSolved).Count;

            sum += _periodTaskService.GetList(x => x.IsSolved).Count;

            sum += _subjectTaskService.GetList(x => x.IsSolved).Count;

            return sum;
        }
        
        private int GetNotSolvedTaskNumber()
        {
            var sum = 0;

            sum += _globalTaskService.GetList(x => !x.IsSolved).Count;

            sum += _periodTaskService.GetList(x => !x.IsSolved).Count;

            sum += _subjectTaskService.GetList(x => !x.IsSolved).Count;

            return sum;
        }
    }
}
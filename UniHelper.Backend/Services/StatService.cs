using System.Collections.Generic;
using System.Linq;
using UniHelper.Backend.Services.Interfaces;
using UniHelper.Shared.DTOs;

namespace UniHelper.Backend.Services;

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
        stat.Periods = new List<PeriodStatistic>();

        var periods = _periodService.GetUserPeriodList();
        
        periods.ForEach(period =>
        {
            stat.Periods.Add(new PeriodStatistic
            {
                IsCurrent = period.IsCurrent,
                Label = period.Name,
                Marks = period.Subjects.Where(x => x.Result != null).Select(x => (int)x.Result).ToList()
            });
        });

        return stat;
    }

    private int GetSolvedTaskNumber()
    {
        var sum = 0;

        sum += _globalTaskService.GetMyList().Count(x => x.IsSolved);

        sum += _periodTaskService.GetMyList().Count(x => x.IsSolved);

        sum += _subjectTaskService.GetMyList().Count(x => x.IsSolved);

        return sum;
    }
    
    private int GetNotSolvedTaskNumber()
    {
        var sum = 0;

        sum += _globalTaskService.GetMyList().Count(x => !x.IsSolved);

        sum += _periodTaskService.GetMyList().Count(x => !x.IsSolved);

        sum += _subjectTaskService.GetMyList().Count(x => !x.IsSolved);

        return sum;
    }
}

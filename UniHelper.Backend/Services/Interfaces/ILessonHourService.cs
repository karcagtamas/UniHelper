using KarcagS.Common.Tools.Repository;
using UniHelper.Backend.Entities;
using UniHelper.Shared.DTOs;

namespace UniHelper.Backend.Services.Interfaces;

/// <summary>
/// Lesson Hour Service
/// </summary>
public interface ILessonHourService : IMapperRepository<LessonHour, int>
{
    /// <summary>
    /// Get hour interval
    /// </summary>
    /// <param name="from">From number</param>
    /// <param name="to">To number</param>
    /// <returns>Hour interval</returns>
    LessonHourIntervalDto GetHourInterval(int from, int to);
}

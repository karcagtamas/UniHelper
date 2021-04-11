using Karcags.Common.Tools;
using UniHelper.Backend.Entities;
using UniHelper.Shared.DTOs;

namespace UniHelper.Backend.Services
{
    /// <summary>
    /// Lesson Hour Service
    /// </summary>
    public interface ILessonHourService : IRepository<LessonHour>
    {
        /// <summary>
        /// Get hour interval
        /// </summary>
        /// <param name="from">From number</param>
        /// <param name="to">To number</param>
        /// <returns>Hour interval</returns>
        LessonHourIntervalDto GetHourInterval(int from, int to);
    }
}
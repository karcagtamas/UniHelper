using System.Threading.Tasks;
using Karcags.Blazor.Common.Services;
using UniHelper.Shared.DTOs;
using UniHelper.Shared.Models;

namespace UniHelper.Services
{
    /// <summary>
    /// Lesson hour Service
    /// </summary>
    public interface ILessonHourService : ICommonService<LessonHourModel, LessonHourDto>
    {
        /// <summary>
        /// Get Hour interval by endpoints
        /// </summary>
        /// <param name="from">From number</param>
        /// <param name="to">To number</param>
        /// <returns>Create Hour interval</returns>
        Task<LessonHourIntervalDto> GetHourInterval(int from, int to);
    }
}
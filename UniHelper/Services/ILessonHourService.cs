using System.Threading.Tasks;
using KarcagS.Blazor.Common.Http;
using UniHelper.Shared.DTOs;

namespace UniHelper.Services
{
    /// <summary>
    /// Lesson hour Service
    /// </summary>
    public interface ILessonHourService : IHttpCall<int>
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
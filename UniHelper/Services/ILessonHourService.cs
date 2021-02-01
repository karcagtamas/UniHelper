using System.Threading.Tasks;
using Karcags.Blazor.Common.Services;
using UniHelper.Shared.DTOs;
using UniHelper.Shared.Models;

namespace UniHelper.Services
{
    public interface ILessonHourService : ICommonService<LessonHourModel, LessonHourDto>
    {
        Task<LessonHourIntervalDto> GetHourInterval(int from, int to);
    }
}
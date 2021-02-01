using Karcags.Common.Tools;
using UniHelper.Backend.Entities;
using UniHelper.Shared.DTOs;

namespace UniHelper.Backend.Services
{
    public interface ILessonHourService : IRepository<LessonHour>
    {
        LessonHourIntervalDto GetHourInterval(int from, int to);
    }
}
using System.Threading.Tasks;
using Karcags.Blazor.Common.Services;
using UniHelper.Shared.DTOs;
using UniHelper.Shared.Models;

namespace UniHelper.Services
{
    public interface IPeriodService : ICommonService<PeriodModel, PeriodDto>
    {
        Task<int> GetCurrent();
        Task<bool> SetCurrent(int id);
    }
}
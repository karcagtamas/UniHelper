using Karcags.Common.Tools;
using UniHelper.Backend.Entities;

namespace UniHelper.Backend.Services
{
    public interface IPeriodService : IRepository<Period>
    {
        int GetCurrent();
        void SetCurrent(int id);
    }
}
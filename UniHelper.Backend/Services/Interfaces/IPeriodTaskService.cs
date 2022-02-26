using KarcagS.Common.Tools.Repository;
using System.Collections.Generic;
using UniHelper.Backend.Entities;
using UniHelper.Shared.DTOs;

namespace UniHelper.Backend.Services.Interfaces;

/// <summary>
/// Period Task Service
/// </summary>
public interface IPeriodTaskService : IMapperRepository<PeriodTask, int>
{
    /// <summary>
    /// Get My List
    /// </summary>
    /// <returns>Task list</returns>
    List<TaskDto> GetMyList();
}

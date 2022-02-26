using System.Collections.Generic;
using KarcagS.Common.Tools.Repository;
using UniHelper.Backend.Entities;
using UniHelper.Shared.DTOs;

namespace UniHelper.Backend.Services.Interfaces;

/// <summary>
/// Period Service
/// </summary>
public interface IPeriodService : IMapperRepository<Period, int>
{
    /// <summary>
    /// Get current Period
    /// </summary>
    /// <returns>Period</returns>
    int GetCurrent();

    /// <summary>
    /// Set current Period
    /// </summary>
    /// <param name="id">New Period's Id</param>
    void SetCurrent(int id);

    /// <summary>
    /// Get user's period list
    /// </summary>
    /// <returns>List of periods</returns>
    List<PeriodDto> GetUserPeriodList();
}

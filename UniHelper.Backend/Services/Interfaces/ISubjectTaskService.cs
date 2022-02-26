using System.Collections.Generic;
using KarcagS.Common.Tools.Repository;
using UniHelper.Backend.Entities;
using UniHelper.Shared.DTOs;

namespace UniHelper.Backend.Services.Interfaces;

/// <summary>
/// Subject Task Service
/// </summary>
public interface ISubjectTaskService : IMapperRepository<SubjectTask, int>
{
    /// <summary>
    /// Get My List
    /// </summary>
    /// <returns>Task list</returns>
    List<TaskDto> GetMyList();
}

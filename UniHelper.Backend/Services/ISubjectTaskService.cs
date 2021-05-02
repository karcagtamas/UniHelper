using System.Collections.Generic;
using Karcags.Common.Tools;
using UniHelper.Backend.Entities;
using UniHelper.Shared.DTOs;

namespace UniHelper.Backend.Services
{
    /// <summary>
    /// Subject Task Service
    /// </summary>
    public interface ISubjectTaskService : IRepository<SubjectTask>
    {
        /// <summary>
        /// Get My List
        /// </summary>
        /// <returns>Task list</returns>
        List<TaskDto> GetMyList();
    }
}
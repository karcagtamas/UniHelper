using Karcags.Common.Tools.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniHelper.Backend.Entities;
using UniHelper.Backend.Services;
using UniHelper.Shared.DTOs;
using UniHelper.Shared.Models;

namespace UniHelper.Backend.Controllers
{
    /// <summary>
    /// Subject Task Controller
    /// </summary>
    [Route("/api/subject-tasks")]
    [ApiController]
    [Authorize]
    public class SubjectTaskController : MyController<SubjectTask, SubjectTaskModel, TaskDto>
    {
        /// <summary>
        /// Init Subject Task Controller
        /// </summary>
        /// <param name="service">Subject Task Service</param>
        public SubjectTaskController(ISubjectTaskService service) : base(service)
        {
        }
    }
}
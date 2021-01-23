using Karcags.Common.Tools.Controllers;
using Microsoft.AspNetCore.Mvc;
using UniHelper.Backend.Entities;
using UniHelper.Backend.Services;
using UniHelper.Shared.DTOs;
using UniHelper.Shared.Models;

namespace UniHelper.Backend.Controllers
{
    [Route("/api/subject-tasks")]
    [ApiController]
    public class SubjectTaskController : MyController<SubjectTask, SubjectTaskModel, TaskDto>
    {
        public SubjectTaskController(ISubjectTaskService service) : base(service)
        {
        }
    }
}
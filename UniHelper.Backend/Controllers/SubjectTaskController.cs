using Karcags.Common.Tools;
using Karcags.Common.Tools.Controllers;
using Microsoft.AspNetCore.Mvc;
using UniHelper.Backend.DTOs;
using UniHelper.Backend.Entities;
using UniHelper.Backend.Models;
using UniHelper.Backend.Services;

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
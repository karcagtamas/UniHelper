using Karcags.Common.Tools.Controllers;
using Microsoft.AspNetCore.Mvc;
using UniHelper.Backend.Entities;
using UniHelper.Backend.Services;
using UniHelper.Shared.DTOs;
using UniHelper.Shared.Models;

namespace UniHelper.Backend.Controllers
{
    [Route("/api/subjects")]
    [ApiController]
    public class SubjectController : MyController<Subject, SubjectModel, SubjectDto>
    {
        public SubjectController(ISubjectService service) : base(service)
        {
        }
    }
}
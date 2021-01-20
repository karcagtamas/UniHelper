using Karcags.Common.Tools;
using Karcags.Common.Tools.Controllers;
using Microsoft.AspNetCore.Mvc;
using UniHelper.Backend.DTOs;
using UniHelper.Backend.Entities;
using UniHelper.Backend.Models;
using UniHelper.Backend.Services;

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
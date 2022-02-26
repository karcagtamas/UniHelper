using KarcagS.Common.Tools.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniHelper.Backend.Entities;
using UniHelper.Backend.Services.Interfaces;
using UniHelper.Shared.DTOs;
using UniHelper.Shared.Models;

namespace UniHelper.Backend.Controllers
{
    /// <summary>
    /// Subject Controller
    /// </summary>
    [Route("/api/subjects")]
    [ApiController]
    [Authorize]
    public class SubjectController : MapperController<Subject, int, SubjectModel, SubjectDto>
    {
        /// <summary>
        /// Init Subject Controller
        /// </summary>
        /// <param name="service">Subject Service</param>
        public SubjectController(ISubjectService service) : base(service)
        {
        }
    }
}
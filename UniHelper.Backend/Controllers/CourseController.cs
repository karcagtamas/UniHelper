using Karcags.Common.Tools;
using Karcags.Common.Tools.Controllers;
using Microsoft.AspNetCore.Mvc;
using UniHelper.Backend.Entities;
using UniHelper.Backend.Services;
using UniHelper.Shared.DTOs;
using UniHelper.Shared.Models;

namespace UniHelper.Backend.Controllers
{
    [Route("/api/courses")]
    [ApiController]
    public class CourseController : MyController<Course, CourseModel, CourseDto>
    {
        public CourseController(ICourseService service) : base(service)
        {
        }
    }
}
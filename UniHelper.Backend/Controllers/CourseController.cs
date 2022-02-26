using KarcagS.Common.Tools;
using KarcagS.Common.Tools.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniHelper.Backend.Entities;
using UniHelper.Backend.Services.Interfaces;
using UniHelper.Shared.DTOs;
using UniHelper.Shared.Models;

namespace UniHelper.Backend.Controllers;

/// <summary>
/// Course Controller
/// </summary>
[Route("/api/courses")]
[ApiController]
[Authorize]
public class CourseController : MapperController<Course, int, CourseModel, CourseDto>
{
    /// <summary>
    /// Course Controller
    /// </summary>
    public CourseController(ICourseService service) : base(service)
    {
    }
}

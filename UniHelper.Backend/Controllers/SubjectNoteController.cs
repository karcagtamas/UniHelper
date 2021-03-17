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
    /// Subject Note Controller
    /// </summary>
    [Route("/api/subject-notes")]
    [ApiController]
    [Authorize]
    public class SubjectNoteController : MyController<SubjectNote, SubjectNoteModel, NoteDto>
    {
        /// <summary>
        /// Init Subject Note Controller
        /// </summary>
        /// <param name="service">Subject Note Service</param>
        public SubjectNoteController(ISubjectNoteService service) : base(service)
        {
        }
    }
}
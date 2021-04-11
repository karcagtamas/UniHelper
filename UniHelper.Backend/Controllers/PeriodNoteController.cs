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
    /// Period Note Controller
    /// </summary>
    [Route("/api/period-notes")]
    [ApiController]
    [Authorize]
    public class PeriodNoteController : MyController<PeriodNote, PeriodNoteModel, NoteDto>
    {
        /// <summary>
        /// Init Period Note Controller
        /// </summary>
        /// <param name="service">Period Note service</param>
        public PeriodNoteController(IPeriodNoteService service) : base(service)
        {
        }
    }
}
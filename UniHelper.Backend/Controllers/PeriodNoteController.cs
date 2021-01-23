using Karcags.Common.Tools.Controllers;
using Microsoft.AspNetCore.Mvc;
using UniHelper.Backend.Entities;
using UniHelper.Backend.Services;
using UniHelper.Shared.DTOs;
using UniHelper.Shared.Models;

namespace UniHelper.Backend.Controllers
{
    [Route("/api/period-notes")]
    [ApiController]
    public class PeriodNoteController : MyController<PeriodNote, PeriodNoteModel, NoteDto>
    {
        public PeriodNoteController(IPeriodNoteService service) : base(service)
        {
        }
    }
}
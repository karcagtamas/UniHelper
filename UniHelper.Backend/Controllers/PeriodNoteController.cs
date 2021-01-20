using Karcags.Common.Tools;
using Karcags.Common.Tools.Controllers;
using Microsoft.AspNetCore.Mvc;
using UniHelper.Backend.DTOs;
using UniHelper.Backend.Entities;
using UniHelper.Backend.Models;
using UniHelper.Backend.Services;

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
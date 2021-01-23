using Karcags.Common.Tools.Controllers;
using Microsoft.AspNetCore.Mvc;
using UniHelper.Backend.Entities;
using UniHelper.Backend.Services;
using UniHelper.Shared.DTOs;
using UniHelper.Shared.Models;

namespace UniHelper.Backend.Controllers
{
    [Route("/api/global-notes")]
    [ApiController]
    public class GlobalNoteController : MyController<GlobalNote, GlobalNoteModel, NoteDto>
    {
        public GlobalNoteController(IGlobalNoteService service) : base(service)
        {
        }
    }
}
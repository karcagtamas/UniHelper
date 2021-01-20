using Karcags.Common.Tools;
using Karcags.Common.Tools.Controllers;
using Microsoft.AspNetCore.Mvc;
using UniHelper.Backend.DTOs;
using UniHelper.Backend.Entities;
using UniHelper.Backend.Models;
using UniHelper.Backend.Services;

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
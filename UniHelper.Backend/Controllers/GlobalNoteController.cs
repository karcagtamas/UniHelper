using Karcags.Common.Tools.Controllers;
using Microsoft.AspNetCore.Mvc;
using UniHelper.Backend.Entities;
using UniHelper.Backend.Services;
using UniHelper.Shared.DTOs;
using UniHelper.Shared.Models;

namespace UniHelper.Backend.Controllers
{
    /// <summary>
    /// Global Note Controller
    /// </summary>
    [Route("/api/global-notes")]
    [ApiController]
    public class GlobalNoteController : MyController<GlobalNote, GlobalNoteModel, NoteDto>
    {
        /// <summary>
        /// Global Note Controller
        /// </summary>
        public GlobalNoteController(IGlobalNoteService service) : base(service)
        {
        }
    }
}
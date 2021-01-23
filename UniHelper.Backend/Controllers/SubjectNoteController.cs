using Karcags.Common.Tools.Controllers;
using Microsoft.AspNetCore.Mvc;
using UniHelper.Backend.Entities;
using UniHelper.Backend.Services;
using UniHelper.Shared.DTOs;
using UniHelper.Shared.Models;

namespace UniHelper.Backend.Controllers
{
    [Route("/api/subject-notes")]
    [ApiController]
    public class SubjectNoteController : MyController<SubjectNote, SubjectNoteModel, NoteDto>
    {
        public SubjectNoteController(ISubjectNoteService service) : base(service)
        {
        }
    }
}
using Karcags.Common.Tools;
using Karcags.Common.Tools.Controllers;
using Microsoft.AspNetCore.Mvc;
using UniHelper.Backend.DTOs;
using UniHelper.Backend.Entities;
using UniHelper.Backend.Models;
using UniHelper.Backend.Services;

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
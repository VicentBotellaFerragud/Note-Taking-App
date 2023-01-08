using Microsoft.AspNetCore.Mvc;
using Note_Taking_App_API.Dtos;
using Note_Taking_App_API.Models;
using Note_Taking_App_API.Services;

namespace Note_Taking_App_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly INotesService notesService;

        public NotesController(INotesService notesService)
        {
            this.notesService = notesService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetNoteDto>>>> GetAll()
        {
            var response = await this.notesService.GetAllNotes();
            if (response.Data is null)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("GetSingle/{noteId}")]
        public async Task<ActionResult<ServiceResponse<GetNoteDto>>> GetSingle(int noteId)
        {
            var response = await this.notesService.GetSingleNote(noteId);
            if (response.Data is null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<ServiceResponse<GetNoteDto>>> Create(CreateNoteDto newNote)
        {
            var response = await this.notesService.CreateNote(newNote);
            if (response.Data is null)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPut("Update/{noteId}")]
        public async Task<ActionResult<ServiceResponse<GetNoteDto>>> Update(int noteId, UpdateNoteDto updatedNote)
        {
            var response = await this.notesService.UpdateNote(noteId, updatedNote);
            if (response.Data is null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpDelete("Delete/{noteId}")]
        public async Task<ActionResult<ServiceResponse<GetNoteDto>>> Delete(int noteId)
        {
            var response = await this.notesService.DeleteNote(noteId);
            if (response.Data is null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}

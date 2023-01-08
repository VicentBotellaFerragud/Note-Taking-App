using Note_Taking_App_API.Dtos;
using Note_Taking_App_API.Models;

namespace Note_Taking_App_API.Services
{
    public interface INotesService
    {
        Task<ServiceResponse<List<GetNoteDto>>> GetAllNotes();
        Task<ServiceResponse<GetNoteDto>> GetSingleNote(int noteId);
        Task<ServiceResponse<GetNoteDto>> CreateNote(CreateNoteDto newNote);
        Task<ServiceResponse<GetNoteDto>> UpdateNote(int noteId, UpdateNoteDto updatedNote);
        Task<ServiceResponse<GetNoteDto>> DeleteNote(int noteId);
    }
}

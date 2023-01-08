using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Note_Taking_App_API.Data;
using Note_Taking_App_API.Dtos;
using Note_Taking_App_API.Models;

namespace Note_Taking_App_API.Services
{
    public class NotesService : INotesService
    {
        private readonly IMapper mapper;
        public DataContext context;

        public NotesService(IMapper mapper, DataContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<ServiceResponse<List<GetNoteDto>>> GetAllNotes()
        {
            var serviceResponse = new ServiceResponse<List<GetNoteDto>>();
            try
            {
                var notes = await this.context.Notes.ToListAsync();
                if (notes is null)
                {
                    throw new Exception($"Notes could not be retrieved");
                }
                serviceResponse.Data = notes.Select(note => this.mapper.Map<GetNoteDto>(note)).ToList();
                serviceResponse.Message = "All notes successfully retrieved.";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetNoteDto>> GetSingleNote(int noteId)
        {
            var serviceResponse = new ServiceResponse<GetNoteDto>();
            try
            {
                var note = await this.context.Notes.FirstOrDefaultAsync(note => note.Id == noteId);
                if (note is null)
                {
                    throw new Exception($"Note with id {noteId} not found");
                }
                serviceResponse.Data = this.mapper.Map<GetNoteDto>(note);
                serviceResponse.Message = $"Note with id {noteId} successfully retrieved.";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetNoteDto>> CreateNote(CreateNoteDto newNote)
        {
            var serviceResponse = new ServiceResponse<GetNoteDto>();
            try
            {
                var note = this.mapper.Map<Note>(newNote);
                if (note is null)
                {
                    throw new Exception($"New note could not be created");
                }
                _ = await this.context.Notes.AddAsync(note);
                _ = await this.context.SaveChangesAsync();
                serviceResponse.Data = this.mapper.Map<GetNoteDto>(note);
                serviceResponse.Message = "New note successfully created.";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetNoteDto>> UpdateNote(int noteId, UpdateNoteDto updatedNote)
        {
            var serviceResponse = new ServiceResponse<GetNoteDto>();
            try
            {
                var note = await this.context.Notes.FirstOrDefaultAsync(note => note.Id == noteId);
                if (note is null)
                {
                    throw new Exception($"Note with id {noteId} not found");
                }
                note.Title = updatedNote.Title;
                note.Description = updatedNote.Description;
                note.Priority = updatedNote.Priority;
                _ = await this.context.SaveChangesAsync();
                serviceResponse.Data = this.mapper.Map<GetNoteDto>(note);
                serviceResponse.Message = $"Note with id {noteId} successfully updated.";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetNoteDto>> DeleteNote(int noteId)
        {
            var serviceResponse = new ServiceResponse<GetNoteDto>();
            try
            {
                var note = await this.context.Notes.FirstOrDefaultAsync(note => note.Id == noteId);
                if (note is null)
                {
                    throw new Exception($"Note with id {noteId} not found");
                }
                serviceResponse.Data = this.mapper.Map<GetNoteDto>(note);
                _ = this.context.Notes.Remove(note);
                _ = this.context.SaveChangesAsync();
                serviceResponse.Message = $"Note with id {noteId} successfully deleted.";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}

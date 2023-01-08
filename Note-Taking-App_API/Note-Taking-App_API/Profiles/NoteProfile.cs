using AutoMapper;
using Note_Taking_App_API.Dtos;
using Note_Taking_App_API.Models;

namespace Note_Taking_App_API.Profiles
{
    public class NoteProfile : Profile
    {
        public NoteProfile()
        {
            CreateMap<Note, GetNoteDto>().ReverseMap();
            CreateMap<Note, CreateNoteDto>().ReverseMap();
        }
    }
}

using Note_Taking_App_API.Models;
using System.ComponentModel.DataAnnotations;

namespace Note_Taking_App_API.Dtos
{
    public class GetNoteDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; } = Priority.Low;
    }
}

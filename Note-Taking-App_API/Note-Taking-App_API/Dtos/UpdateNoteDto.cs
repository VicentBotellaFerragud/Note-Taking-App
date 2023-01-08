using Note_Taking_App_API.Models;

namespace Note_Taking_App_API.Dtos
{
    public class UpdateNoteDto
    {
        public string Title { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public Priority Priority { get; set; } = Priority.Low;
    }
}

using Note_Taking_App_API.Models;
using System.ComponentModel.DataAnnotations;

namespace Note_Taking_App_API.Dtos
{
    public class UpdateNoteDto
    {
        [StringLength(20)]
        public string Title { get; set; }
        [StringLength(150)]
        public string Description { get; set; }
        public Priority Priority { get; set; } = Priority.Low;
    }
}

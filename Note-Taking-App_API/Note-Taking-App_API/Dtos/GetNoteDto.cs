using Note_Taking_App_API.Models;
using System.ComponentModel.DataAnnotations;

namespace Note_Taking_App_API.Dtos
{
    public class GetNoteDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Title { get; set; }
        [Required]
        [StringLength(150)]
        public string Description { get; set; }
        [Required]
        public Priority Priority { get; set; } = Priority.Low;
    }
}

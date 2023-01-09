using System.ComponentModel.DataAnnotations;

namespace Note_Taking_App_API.Models
{
    public class Note
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string Title { get; set; }
        [StringLength(150)]
        public string Description { get; set; }
        public Priority Priority { get; set; } = Priority.Low;
    }
}

using System.ComponentModel.DataAnnotations;

namespace NoteApplication_Exam_Bridgeon.Entities.Models.DTO
{
    public class NoteInputDTO
    {
        [Required]
        public string Title { get; set; }

        public string? Description { get; set; }

    
        public string? Color { get; set; }

    }
}

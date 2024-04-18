using System.ComponentModel.DataAnnotations;

namespace NoteApplication_Exam_Bridgeon.Entities.Models.DTO
{
    public class UserInputDTO
    {
        [Required]
        public string Name { get; set; }

    }
}

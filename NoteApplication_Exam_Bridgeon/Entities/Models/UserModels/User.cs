using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using NoteApplication_Exam_Bridgeon.Entities.Models.NoteModels;

namespace NoteApplication_Exam_Bridgeon.Entities.Models.UserModels
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        public ICollection<Note> Notes { get; set; }

    }
}

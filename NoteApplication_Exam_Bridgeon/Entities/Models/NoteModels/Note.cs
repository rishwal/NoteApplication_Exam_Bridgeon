using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NoteApplication_Exam_Bridgeon.Entities.Models.UserModels;

namespace NoteApplication_Exam_Bridgeon.Entities.Models.NoteModels
{
    public class Note
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NoteId { get; set; }


        public DateTime? Date { get; set; }

        [Required]
        public string Title { get; set; }

        public string? Description { get; set; }

        public Enum? Color { get; set; }



        public int UserId { get; set; }
        public User User { get; set; }


    }
}

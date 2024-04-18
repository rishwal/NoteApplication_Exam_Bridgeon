using NoteApplication_Exam_Bridgeon.Entities.Models.DTO;

namespace NoteApplication_Exam_Bridgeon.Entities.Models.NoteModels
{
    public interface INoteRepository
    {

        Task<Note> CreateNewNote(Note note, int userId);
        Task<IEnumerable<Note>> GetNotesByIdAsync(int noteId, int userId);

        Task<IEnumerable<Note>> GetAllNotesOfUserAsync(int userId);

        Task<bool> DeleteNoteAsync(int noteId, int userId);





    }
}

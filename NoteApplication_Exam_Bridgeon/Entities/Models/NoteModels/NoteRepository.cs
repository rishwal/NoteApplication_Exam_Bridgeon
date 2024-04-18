using Microsoft.EntityFrameworkCore;
using NoteApplication_Exam_Bridgeon.Data.AppliactionDbContext;
using NoteApplication_Exam_Bridgeon.Entities.Models.DTO;
using NoteApplication_Exam_Bridgeon.Entities.Models.UserModels;

namespace NoteApplication_Exam_Bridgeon.Entities.Models.NoteModels
{
    public class NoteRepository : INoteRepository
    {

        private readonly NoteDbContext _dbContext;


        public NoteRepository(NoteDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public async Task<Note?> CreateNewNote(Note note, int userId)
        {
            try
            {
                if (note != null && userId != 0)
                {

                    User? userToAddTask = await _dbContext.Users.FirstOrDefaultAsync(user => user.UserId == userId);

                    if (userToAddTask != null)
                    {

                        var noteToAdd = new Note
                        {
                            Title = note.Title,
                            Description = note.Description,
                            Date = DateTime.Now,
                            Color = note.Color,
                            UserId = userId

                        };


                        userToAddTask.Notes.Add(noteToAdd);

                        await _dbContext.SaveChangesAsync();

                        return noteToAdd;
                    }
                    else
                    {
                        return null;
                        throw new Exception("User Not Found in the userList with user Id :" + userId);

                    }

                }
                else
                {
                    return null;
                    throw new Exception("User can't be null or id !");
                }


            }
            catch (Exception)
            {
                throw new Exception("User C:" + userId);
                throw;
            }
        }

        public async Task<bool> DeleteNoteAsync(int userId, int noteId)
        {
            try
            {
                if (noteId != 0 || userId != 0)
                {
                    User? user = await _dbContext.Users.FirstOrDefaultAsync(u => u.UserId == userId);

                    if (user != null)
                    {
                        Note? taskToRemove = user.Notes.FirstOrDefault(n => n.NoteId == noteId);
                        if (taskToRemove != null)
                        {
                            user.Notes.Remove(taskToRemove);
                            await _dbContext.SaveChangesAsync();

                            return true;
                        }
                        else
                        {
                            return false;
                            throw new Exception("An exception occured while removing a new note");
                        }



                    }

                    return false;

                }
                else
                {
                    return false;
                    throw new Exception("UserId or NoteId can't be null! ");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("There happend an exception while deleting the task !" + ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<Note>?> GetAllNotesOfUserAsync(int userId)
        {
            try
            {
                if (userId != 0)
                {
                    var currentUser = await _dbContext.Users.FirstOrDefaultAsync(user => user.UserId == userId);
                    if (currentUser != null)
                    {
                        var TaskOfuser = currentUser.Notes.ToList();
                        if (TaskOfuser != null)
                        {
                            return TaskOfuser;
                        }

                        return null;
                    }
                    else
                    {
                        return null;
                        throw new Exception("An exception occured userId can't be null");

                    }


                }
                else
                {
                    return null;
                    throw new Exception("The userId can't be null");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("There happend an exception while get all notes !" + ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<Note>?> GetNotesByIdAsync(int noteId, int userId)
        {
            try
            {
                if (noteId != 0 && userId != 0)
                {
                    User? user = await _dbContext.Users.FirstOrDefaultAsync(u => u.UserId == userId);

                    if (user != null)
                    {
                        List<Note>? notes = [.. user.Notes];

                        if (notes != null) return notes;
                        else return null;

                    }
                    else
                    {
                        return null;
                        throw new Exception($"user not found with id {userId}");

                    }
                }
                else
                {
                    return null;
                    throw new Exception("UserId pr taskID can't be null");

                }
            }
            catch (Exception ex)
            {
                throw new Exception("An exception occured while getting notes by Id" + ex.Message);
                throw;
            }
        }
    }
}

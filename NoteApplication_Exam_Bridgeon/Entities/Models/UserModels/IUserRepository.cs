namespace NoteApplication_Exam_Bridgeon.Entities.Models.UserModels
{
    public interface IUserRepository
    {
        Task<bool> CreateUser(User user);

        Task<List<User>> GetAllUsers();

        Task<User> GetUserById(int userId);
        Task<bool> Removeuser(int id);
    }
}

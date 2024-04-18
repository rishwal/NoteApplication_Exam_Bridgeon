using Microsoft.EntityFrameworkCore;
using NoteApplication_Exam_Bridgeon.Data.AppliactionDbContext;
using NoteApplication_Exam_Bridgeon.Entities.Models.NoteModels;

namespace NoteApplication_Exam_Bridgeon.Entities.Models.UserModels
{
    public class UserRepository : IUserRepository
    {

        private readonly NoteDbContext _context;

        public UserRepository(NoteDbContext context)
        {
            _context = context ?? throw new ArgumentNullException();
        }

        public async Task<bool> CreateUser(User user)
        {
            try
            {
                if (user != null)
                {


                    var userToAdd = new User
                    {
                        UserName = user.UserName,
                        Notes = [],

                    };

                    await _context.Users.AddAsync(user);
                    await _context.SaveChangesAsync();


                }
                else
                {
                    return false;
                    throw new Exception();
                }

                return false;

            }
            catch (Exception ex)
            {
                return false;
                throw new Exception("User Creation failed!" + ex.Message);
            }
        }

        public async Task<List<User>?> GetAllUsers()
        {
            try
            {


                List<User>? usr = await _context.Users.ToListAsync();


                return usr ?? null;




            }
            catch (Exception ex)
            {
                return null;
                throw new Exception("An excption occured while getting all users!");

            }
        }

        public async Task<User?> GetUserById(int userId)
        {
            try
            {
                User? user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);

                if (user != null)
                {
                    return user;
                }
                else
                {
                    return null;
                    throw new Exception($"user Not Found in the provided id {userId}");
                }

            }
            catch (Exception ex)
            {
                throw new Exception($"An Exception ocured while gettig the user with id {userId}");
                throw;
            }
        }

        public async Task<bool> Removeuser(int userId)
        {
            try
            {
                if (userId != 0)
                {
                    var userToRemove = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);
                    if (userToRemove != null)
                    {
                        _context.Users.Remove(userToRemove);
                        _context.SaveChanges();

                        return true;
                    }
                    else
                    {
                        return false;
                        throw new Exception("User deletion failed !");
                    }



                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception("User Removal failed !" + ex.Message);
                throw;
            }
        }
    }
}

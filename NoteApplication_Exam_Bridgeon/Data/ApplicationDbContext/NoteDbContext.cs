using Microsoft.EntityFrameworkCore;
using NoteApplication_Exam_Bridgeon.Entities.Models.NoteModels;
using NoteApplication_Exam_Bridgeon.Entities.Models.UserModels;

namespace NoteApplication_Exam_Bridgeon.Data.AppliactionDbContext
{
    public class NoteDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;


        public NoteDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration["ConnectionString:DefaultConnection"];
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>()
                .HasOne(n => n.User) // Note belongs to one User
                .WithMany(u => u.Notes) // User can have many Notes
                .HasForeignKey(n => n.UserId) // Foreign key on Note
                .HasPrincipalKey(u => u.UserId); // Principal key on User

            base.OnModelCreating(modelBuilder);
        }







    }
}

using Microsoft.EntityFrameworkCore;
using StudentProfile.Domain;

namespace StudentProfile.Persistence.Context
{
    public class StudentProfileContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Skill> Skills { get; set; }

        public StudentProfileContext()
        {

        }

        public StudentProfileContext(DbContextOptions<StudentProfileContext> options)
            : base(options) { }        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=StudentProfile;Trusted_Connection=True;");
        }
    }
}

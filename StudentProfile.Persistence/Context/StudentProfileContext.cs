using Microsoft.EntityFrameworkCore;
using StudentProfile.Domain;

namespace StudentProfile.Persistence.Context
{
    public class StudentProfileContext : DbContext
    {
        DbSet<Student> Students { get; set; }
        DbSet<Teacher> Teachers { get; set; }
        DbSet<Event> Events { get; set; }
        DbSet<Skill> Skills { get; set; }

        public StudentProfileContext(DbContextOptions<StudentProfileContext> options)
            : base(options) { }        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}

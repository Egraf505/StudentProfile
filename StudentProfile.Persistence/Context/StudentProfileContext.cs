using Microsoft.EntityFrameworkCore;
using StudentProfile.Application.Interfaces;
using StudentProfile.Domain;
using StudentProfile.Persistence.EntityTypeConfigurations;

namespace StudentProfile.Persistence.Context
{
    public class StudentProfileContext : DbContext, IStudentProfileContext
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
            builder.ApplyConfiguration(new EventConfiguration());
            builder.ApplyConfiguration(new SkillConfiguration());
            builder.ApplyConfiguration(new StudentConfiguration());
            builder.ApplyConfiguration(new TeacherConfiguration());
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=StudentProfile;Trusted_Connection=True;");
        }
    }
}

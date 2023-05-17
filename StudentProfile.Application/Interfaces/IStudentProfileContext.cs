using Microsoft.EntityFrameworkCore;
using StudentProfile.Domain;

namespace StudentProfile.Application.Interfaces
{
    public interface IStudentProfileContext
    {
        public DbSet<StudentProfile.Domain.Student> Students { get; set; }
        public DbSet<StudentProfile.Domain.Teacher> Teachers { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Skill> Skills { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

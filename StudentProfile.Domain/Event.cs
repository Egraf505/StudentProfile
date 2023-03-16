
namespace StudentProfile.Domain
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public Teacher CreatedTeacher { get; set; } = null!;
        public IEnumerable<Student> Students { get; set; } = null!;
        public IEnumerable<Skill> Skills { get; set; } = null!;
    }
}

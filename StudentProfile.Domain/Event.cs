
namespace StudentProfile.Domain
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public Teacher CreatedTeacher { get; set; } = null!;
        public List<Student> Students { get; set; } = null!;
        public List<Skill> Skills { get; set; } = null!;
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
    }
}

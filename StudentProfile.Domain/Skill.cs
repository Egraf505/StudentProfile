
namespace StudentProfile.Domain
{
    public class Skill
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public List<Student> Students { get; set; } = null!;
        public List<Event> Events { get; set; } = null!;
    }
}


namespace StudentProfile.Domain
{
    public class Skill
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Point { get; set; }
        public List<Student>? Students { get; set; } = null!;
        public List<Event>? Events { get; set; } = null!;
    }
}

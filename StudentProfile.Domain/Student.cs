
namespace StudentProfile.Domain
{
    public class Student
    {
        public int Id { get; set; }

        public string Login { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string Name { get; set;} = null!;
        public string SurName { get; set; } = null!;
        public string? MiddleName { get; set;}

    }
}

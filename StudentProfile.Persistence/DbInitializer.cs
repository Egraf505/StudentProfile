using StudentProfile.Persistence.Context;

namespace StudentProfile.Persistence
{
    public static class DbInitializer
    {   
        public static void Initializer(StudentProfileContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}

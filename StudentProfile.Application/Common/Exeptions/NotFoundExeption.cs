
namespace StudentProfile.Application.Common.Exeptions
{
    public class NotFoundExeption : Exception
    {
        public NotFoundExeption(string name, object key)
            : base($"Entity: \"{name}\" ({key}) not found") { }      
    }
}

using MediatR;

namespace StudentProfile.Application.Events.Commnad.UpdateEvent
{
    public class UpdateEventCommnad : IRequest<Unit>
    {
        public int TeacherId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; } 

    }
}

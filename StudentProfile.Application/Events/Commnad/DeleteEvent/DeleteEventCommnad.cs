using MediatR;

namespace StudentProfile.Application.Events.Commnad.DeleteEvent
{
    public class DeleteEventCommnad : IRequest<Unit>
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
    }
}

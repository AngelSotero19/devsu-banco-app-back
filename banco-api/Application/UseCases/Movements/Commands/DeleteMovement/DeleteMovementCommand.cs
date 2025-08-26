using MediatR;

namespace banco_api.Application.UseCases.Movements.Commands.DeleteMovement
{
    public class DeleteMovementCommand : IRequest<string>
    {
        public string Id { get; }

        public DeleteMovementCommand(string id)
        {
            Id = id;
        }
    }
}

using MediatR;

namespace banco_api.Application.UseCases.Movements.Commands.UpdateMovement
{
    public class UpdateMovementCommand(string pId, UpdateMovementRequest request) : IRequest<string>
    {
        public string Id { get; set; } = pId;

        public string AccountId { get; set; } = request.AccountId;

        public DateTime? Date { get; set; } = request.Date;

        public string MovementType { get; set; } = request.MovementType;

        public decimal? Value { get; set; } = request.Value;

        public decimal? Balance { get; set; } = request.Balance;
    }
}

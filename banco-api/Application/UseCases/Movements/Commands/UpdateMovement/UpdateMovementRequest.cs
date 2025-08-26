using MediatR;

namespace banco_api.Application.UseCases.Movements.Commands.UpdateMovement
{
    public class UpdateMovementRequest : IRequest<string>
    {
        public string AccountId { get; set; }

        public DateTime? Date { get; set; }

        public string MovementType { get; set; }

        public decimal? Value { get; set; }

        public decimal? Balance { get; set; }
    }
}

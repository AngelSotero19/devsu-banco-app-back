using AutoMapper;
using banco_api.Application.Interfaces.Repositories;
using banco_api.Application.UseCases.Reports.Dtos;
using MediatR;

namespace banco_api.Application.UseCases.Reports.Queries.GetStatementReport
{
    public class GetStatementReportHandler : IRequestHandler<GetStatementReportQuery, IEnumerable<StatementMovementDto>>
    {
        private readonly IMovementRepository _movementRepository;
        private readonly IMapper _mapper;

        public GetStatementReportHandler(IMovementRepository movementRepository, IMapper mapper)
        {
            _movementRepository = movementRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StatementMovementDto>> Handle(GetStatementReportQuery request, CancellationToken cancellationToken)
        {
            var movements = await _movementRepository
                .GetByClientAndDateRangeAsync(request.ClientId, request.StartDate, request.EndDate);

            return _mapper.Map<IEnumerable<StatementMovementDto>>(movements);
        }
    }
}

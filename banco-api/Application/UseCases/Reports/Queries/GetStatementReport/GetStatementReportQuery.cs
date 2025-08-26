using banco_api.Application.UseCases.Reports.Dtos;
using MediatR;

namespace banco_api.Application.UseCases.Reports.Queries.GetStatementReport
{
    public class GetStatementReportQuery : IRequest<IEnumerable<StatementMovementDto>>
    {
        public string ClientId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public GetStatementReportQuery(string clientId, DateTime startDate, DateTime endDate)
        {
            ClientId = clientId;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}

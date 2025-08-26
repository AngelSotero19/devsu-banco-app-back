namespace banco_api.Application.UseCases.Reports.Dtos
{
    public class StatementReportResult
    {
        public string ClientId { get; set; }
        public string ClientName { get; set; }
        public string AccountNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<StatementMovementDto> Movements { get; set; } = new();
    }
}

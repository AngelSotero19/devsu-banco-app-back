namespace banco_api.Application.UseCases.Reports.Dtos
{
    public class StatementReportDto
    {
        public string ClientName { get; set; }
        public List<StatementAccountDto> Accounts { get; set; } = new();
    }
}

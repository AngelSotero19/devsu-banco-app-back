namespace banco_api.Application.UseCases.Reports.Dtos
{
    public class StatementAccountDto
    {
        public string AccountNumber { get; set; }
        public decimal FinalBalance { get; set; }
        public List<StatementMovementDto> Movements { get; set; } = new();
    }
}

namespace banco_api.Application.UseCases.Reports.Dtos
{
    public class StatementMovementDto
    {
        public DateTime? Date { get; set; }               
        public string MovementType { get; set; } = "";    
        public decimal? Value { get; set; }               
        public decimal? Balance { get; set; }
        public string AccountNumber { get; set; }
        public string ClientName { get; set; }
    }
}

namespace banco_api.Application.UseCases.Movements.Dtos
{
    public class MovementDto
    {
        public string Id { get; set; }

        public string AccountId { get; set; }

        public string Account { get; set; }

        public DateTime? Date { get; set; }

        public string MovementType { get; set; }

        public decimal? Value { get; set; }

        public decimal? Balance { get; set; }
    }

    public class MovementInsertRequest
    {
        public string AccountId { get; set; }

        public DateTime? Date { get; set; }

        public string MovementType { get; set; }

        public decimal? Value { get; set; }

        public decimal? Balance { get; set; }
    }

    public class MovementUpdateRequest
    {
        public string Id { get; set; }

        public string AccountId { get; set; }

        public DateTime? Date { get; set; }

        public string MovementType { get; set; }

        public decimal? Value { get; set; }

        public decimal? Balance { get; set; }
    }
}

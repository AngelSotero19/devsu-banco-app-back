namespace banco_api.Application.UseCases.Accounts.Dtos
{
    public class AccountDto
    {
        public string Id { get; set; }

        public string AccountTypeId { get; set; }

        public string AccountType { get; set; }

        public string ClientId { get; set; }

        public string Client { get; set; }

        public string AccountNumer { get; set; }

        public decimal? InitialBalance { get; set; }

        public bool? Status { get; set; }
    }

    public class AccountToggleRequest
    {
        public string Id { get; set; }
        public bool? NewStatus { get; set; }
    }

    public class AccountInsertRequest
    {
        public string AccountTypeId { get; set; }

        public string ClientId { get; set; }

        public string AccountNumer { get; set; }

        public decimal? InitialBalance { get; set; }

        public bool? Status { get; set; }
    }

    public class AccountUpdateRequest
    {
        public string Id { get; set; }

        public string AccountTypeId { get; set; }

        public string ClientId { get; set; }

        public string AccountNumer { get; set; }

        public decimal? InitialBalance { get; set; }

        public bool? Status { get; set; }
    }
}

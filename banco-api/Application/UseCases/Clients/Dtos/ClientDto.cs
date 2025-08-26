namespace banco_api.Application.UseCases.Clients.Dtos
{
    public class ClientDto
    {
        public string Id { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
        public string PersonId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Credential { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }

    public class ClientToggleRequest
    {
        public string Id { get; set; }
        public bool? NewStatus { get; set; }
    }

    public class ClientInsertRequest
    {
        public string PersonId { get; set; }

        public string Password { get; set; }

        public bool? Status { get; set; }
    }

    public class ClientUpdateRequest
    {
        public string Id { get; set; }

        public string PersonId { get; set; }

        public string Password { get; set; }

        public bool? Status { get; set; }
    }
}

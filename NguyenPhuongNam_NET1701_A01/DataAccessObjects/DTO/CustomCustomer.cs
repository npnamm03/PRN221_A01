namespace DataAccessObjects.DTO
{
    public class CustomCustomer
    {
        public int CustomerId { get; set; }

        public string? CustomerFullName { get; set; }

        public string? Telephone { get; set; }

        public string EmailAddress { get; set; } = null!;

        public DateOnly? CustomerBirthday { get; set; }

        public string? CustomerStatus { get; set; }

        public string? Password { get; set; }

    }
}

namespace CompanyName.Domain.Api
{
    public class RegisterApiRequest
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
    }
}

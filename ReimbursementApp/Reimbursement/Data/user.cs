namespace Reimbursement.Data
{
    public class User
    {
        public User(string? emailAddress, string? name)
        {
            Name = name;
            EmailAddress = emailAddress;
        }

        public long UserId { get; set; }
        public string? EmailAddress { get; set; }
        public string? Name { get; set; }
        public string? Groups { get; set; }
    }
}

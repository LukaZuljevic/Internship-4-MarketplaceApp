namespace Internship_4_MarketplaceApp.Domain.Classes
{
    public abstract class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Guid Id { get; }

        public User(string name, string email)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
        }
        public User() {}

        public abstract string ToString();
    }
}

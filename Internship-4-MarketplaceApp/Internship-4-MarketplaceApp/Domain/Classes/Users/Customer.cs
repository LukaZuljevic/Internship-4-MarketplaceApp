namespace Internship_4_MarketplaceApp.Domain.Classes.Users
{
    public class Customer : User
    {
        public double Balance { get; private set; }

        public Customer(string name, string email, double balance) : base(name, email)
        {
            Balance = balance;
        }

        public override string ToString()
        {
            return $"Ime: {Name}, Email: {Email}, Stanje racuna: {Balance}";
        }
    }
}

namespace Internship_4_MarketplaceApp.Domain.Classes.Users
{
    public class Salesman : User
    {
        public double Earnings { get; private set;}

        public Salesman(string name, string email) : base(name, email)
        {

        }

        public override string ToString()
        {
            return $"Name: {Name}, Email: {Email}, Earnings: {Earnings}";
        }
    }
}

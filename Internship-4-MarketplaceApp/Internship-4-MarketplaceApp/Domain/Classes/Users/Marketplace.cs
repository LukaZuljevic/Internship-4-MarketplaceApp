namespace Internship_4_MarketplaceApp.Domain.Classes.Users
{
    public class Marketplace
    {
        public List<User> Users { get; set; }
        
        public Marketplace()
        {
            Users = new List<User>();
        }

        public void AddNewUser(User newUser)
        {
            Users.Add(newUser);
        }

        public void PrintUsers()
        {
            foreach(var user in Users)
            {
                Console.WriteLine($"Ime: {user.Name}, Email: {user.Email}");
            }
        }
    }
}

namespace Internship_4_MarketplaceApp.Domain.Classes
{
    public class Marketplace
    {
        public List<User> Users { get; }
        public List<Product> ListOfProducts { get; }

        public Marketplace()
        {
            Users = new List<User>();
            ListOfProducts = new List<Product>();

        }

        public void AddNewUser(User newUser)
        {
            Users.Add(newUser);
        }

        public void AddNewProduct(Product newProduct)
        {
            ListOfProducts.Add(newProduct);
        }

        public void PrintUsers()
        {
            foreach (var user in Users)
            {
                Console.WriteLine($"Ime: {user.Name}, Email: {user.Email}");
            }
        }
    }
}

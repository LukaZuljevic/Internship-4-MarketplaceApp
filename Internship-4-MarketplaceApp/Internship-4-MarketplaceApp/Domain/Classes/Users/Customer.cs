namespace Internship_4_MarketplaceApp.Domain.Classes.Users
{
    public class Customer : User
    {
        public double Balance { get; private set; }
        public List<Product> BoughtProducts { get; set; }

        public Customer(string name, string email, double balance) : base(name, email)
        {
            Balance = balance;
            BoughtProducts = new List<Product>();
        }

        public void BuyProduct(Product product)
        {
            BoughtProducts.Add(product);
        }            

        public void SetBalance(double amount)
        {
            Balance += amount;
        }

        public void PrintBoughtProducts()
        {
            foreach(var product in BoughtProducts)
            {
                Console.WriteLine($"Proizvod: {product.Id} - {product.Name} - {product.ProductType} - {product.Description}");
            }
        }

        public override string ToString()
        {
            return $"Ime: {Name}, Email: {Email}, Stanje racuna: {Balance}";
        }
    }
}

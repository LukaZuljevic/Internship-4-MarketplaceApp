namespace Internship_4_MarketplaceApp.Domain.Classes.Users
{
    public class Customer : User
    {
        public double Balance { get; private set; }
        public List<Product> BoughtProducts { get; set; }
        public List<Product> FavoriteProducts { get; set; }

        public Customer(string name, string email, double balance) : base(name, email)
        {
            Balance = balance;
            BoughtProducts = new List<Product>();
            FavoriteProducts = new List<Product>();
        }

        public void BuyProduct(Product product)
        {
            BoughtProducts.Add(product);
        }

        public void ReturnProduct(Product product, Marketplace marketplace)
        {
            if (!BoughtProducts.Contains(product))
            {
                Console.WriteLine("Taj proizvod nije tvoj.\n");
                return;
            }

            Transaction newTransaction = new Transaction(this, product.Salesman, DateTime.Now, Data.Enum.TransactionType.Povrat);
            marketplace.AddNewTransaction(newTransaction);

            BoughtProducts.Remove(product);
            product.Salesman.SoldProducts.Remove(product);

            product.OnSale();

            product.Salesman.SetEarnings((-product.Price + 0.15*product.Price));
            SetBalance(product.Price * 0.8);
        }

        public void SetBalance(double amount)
        {
            Balance += amount;
        }

        public void PrintBoughtProducts()
        {
            Console.Clear();
            if(BoughtProducts.Count == 0)
            {
                Console.WriteLine("Nisi jos nista kupio!\n");
                return;
            }

            Console.WriteLine("Kupljeni proizvodi\n");
            foreach(var product in BoughtProducts)
            {
                Console.WriteLine(product.ToString());
            }
            Console.WriteLine("\n");
        }

        public void AddProductToFavorite(Product product)
        {
            Console.Clear();
            FavoriteProducts.Add(product);
            Console.WriteLine("Uspjesno dodan proizvodi u favorite!\n");
        }

        public void PrintFavouriteProducts()
        {
            Console.Clear();
            if (FavoriteProducts.Count == 0) 
            {
                Console.WriteLine("Nemas proizvoda u favoritima\n");
                return;
            }

            Console.WriteLine("Lista favorita:\n");
            foreach(var product in FavoriteProducts)
            {
                Console.WriteLine(product.ToString());
            }
            Console.WriteLine("\n");
        }

        public override string ToString()
        {
            return $"Ime: {Name}, Email: {Email}, Stanje racuna: {Balance}";
        }
    }
}
